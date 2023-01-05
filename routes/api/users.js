const express = require("express");
const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
const auth = require("../../middleware/auth");
require("dotenv").config();
const router = express.Router();
const db = require("../../model");

router.use(express.json());

router.get("/", auth, (req, res) => {
  db.users
    .find({})
    .then((e) => {
      res.status(200).json(e);
    })
    .catch(() => {
      res.status(404).json({ message: "Cannot Get Users" });
    });
});

router.post("/register", (req, res) => {
  const { last_name, first_name, email, gender, password } = req.body;

  if (last_name && first_name && email && gender && password) {
    db.users.find({ email: req.body.email }).then(async (e) => {
      if (e.length !== 0) {
        return res.status(409).json({ message: "User already exist" });
      }
      const user = await db.users.create({
        last_name,
        first_name,
        email: email.toLowerCase(),
        gender,
        password: await bcrypt.hash(password, 10),
      });

      const token = jwt.sign(
        { user_id: user._id, email },
        process.env.TOKEN_KEY,
        { expiresIn: "2h" }
      );
      user.token = token;
      res.status(201).json(user);
    });
  } else {
    res.status(400).json({ message: "All input is required" });
  }
});

router.post("/login", (req, res) => {
  const { email, password } = req.body;
  if (email && password) {
    db.users.findOne({ email: req.body.email }).then(async (user) => {
      if (user && (await bcrypt.compare(password, user.password))) {
        const token = jwt.sign(
          { user_id: user._id, email },
          process.env.TOKEN_KEY,
          { expiresIn: "2h" }
        );
        user.token = token;
        return res
          .status(200)
          .json({ user, message: "User Connected", token: token });
      }
      return res.status(400).json({ message: "Invalid Credentials" });
    });
  } else {
    res.status(400).json({ message: "All input is required" });
  }
});

router.get("/:email", (req, res) => {
  db.users
    .find({ email: req.params.email })
    .then((e) => {
      res.status(200).json(e);
    })
    .catch(() => {
      res.status(404).json({ message: "Cannot Get User" });
    });
});

module.exports = router;
