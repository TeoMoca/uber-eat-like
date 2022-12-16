//imports
const express = require("express");
const usersRouter = require("./routes/api/users");
require("dotenv").config();

const app = express();
console.log("coucou");
app.use("/users", usersRouter);
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Server Start
app.listen(process.env.SERVER_PORT, () => {
  console.log(`Launching Server on PORT ${process.env.SERVER_PORT}`);
});

//connection to MongoDB
const mongoose = require("mongoose");
mongoose
  .connect(
    `mongodb://${process.env.MONGODB_HOST}:${process.env.MONGODB_PORT}/${process.env.MONGODB_DB}`,
    {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    }
  )
  .then(() => {
    console.log("Connexion à MongoDB réussie !");
  })
  .catch(() => {
    console.log("Connexion à MongoDB échouée !");
  });
