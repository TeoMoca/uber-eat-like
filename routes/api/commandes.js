const express = require("express");
const router = express.Router();
const db = require("../../model");

router.use(express.json());

router.get("/:id", (req, res) => {});

module.exports = router;
