const mongoose = require("mongoose");
mongoose.Promise = global.Promise;

const db = {};
db.mongoose = mongoose;

//Schemas Imports
db.users = require("./users.model");

module.exports = db;
