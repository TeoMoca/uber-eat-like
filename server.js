const http = require("http");
const host = "localhost";
const port = 8080;

const server = http.createServer((req, res) => {
  res.end("Voici la réponse du serveur");
});
server.listen(port, host);
