const mongoose = require("mongoose");

const Orders = mongoose.model(
  "Orders",
  new mongoose.Schema({
    products: { type: Array, required: true },
    user: { type: String, required: true },
  })
);
