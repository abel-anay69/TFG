var express = require('express');
var router = express.Router();
var usuarios = require("../controllers/usuarios");

const bodyParser = require('body-parser').json()

router.get("/usuarios", usuarios.list);
router.get("/usuarios/:nombreUsuario", usuarios.get);
router.get("/usuarios/:nombreUsuario/:password", usuarios.log); // LOGIN
router.post("/usuarios", bodyParser, usuarios.add); //BodyParser es el contenido que hay en el json
router.put("/usuarios/:nombreUsuario", bodyParser, usuarios.update); //Equivalente al update
router.delete("/usuarios/:nombreUsuario", usuarios.delete);

module.exports = router;