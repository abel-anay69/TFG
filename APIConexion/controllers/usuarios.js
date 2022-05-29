require('dotenv').config()
var MongoClient = require('mongodb').MongoClient
const url = process.env.MONGO_URL

exports.get = (req, res) => {
    MongoClient.connect(url, (err, db) => {
        var code = req.params.nombreUsuario;
        if (err) throw err;
        var dbo = db.db('DarkUnity');

        dbo.collection('usuarios').findOne({nombreUsuario:code}, (err, result) => {
            if (err) throw err;
            console.log(result)
            db.close();
            return res.json(result);
        })    
    })
}

// LOGIN
exports.log = (req, res) => {
    MongoClient.connect(url, (err, db) => {
        var code = req.params.nombreUsuario;
        var pwd = req.params.password;
        if (err) throw err;
        var dbo = db.db('DarkUnity');

        dbo.collection('usuarios').findOne({nombreUsuario:code, password: pwd}, (err, result) => {
            if (err) throw err;

            if (result != null) {
                console.log(result)
                return res.json(result)
                
            } else {
                console.log(result)
                return res.status(500).json(result)
            }
        })    
    })
}

exports.list = (req, res) => {
    MongoClient.connect(url, (err, db) => {
        if (err) throw err;
        var dbo = db.db("DarkUnity");

        result = dbo.collection('usuarios').find({}).toArray((err, result) => {
            if (err) throw err;
            console.log(result)
            db.close();
            return res.json(result)
        }) 
    })
}

//REGISTRO
exports.add = (req, res) => {
    MongoClient.connect(url, (err, db) => {
        if (err) throw err;
        var dbo = db.db("DarkUnity");

        var json = JSON.parse(JSON.stringify(req.body));
        var newData = {
            _id: "u" + Math.floor(100000 + Math.random() * 900000),
            nombreUsuario: json.nombreUsuario,
            password: json.password,
            puntos: json.puntos
           
        }

        dbo.collection("usuarios").insertOne(newData), (err, result) => {
            if (err)    console.log(err);
            else{
                console.log(result);
                db.close();
            }
        };
    });
    res.end();
}

exports.update = (req, res) => {
    var json = JSON.parse(JSON.stringify(req.body));
    console.log(json)
    var nuevosDatos = {
        nombreUsuario: json.nombreUsuario,
        password: json.password,
        puntos: json.puntos
        
    }
    MongoClient.connect(url, (err, db) => {
        if (err) throw err;
        var dbo = db.db("DarkUnity");
        dbo.collection("usuarios").updateOne({nombreUsuario:json.nombreUsuario}, {$set:nuevosDatos}, (err, result) => {
            if (err) throw err;
            console.log(result);
            db.close();
        });
        res.end();
    });
}

exports.delete = (req, res) => {
    var code = req.params.id;

    MongoClient.connect(url, (err, db) => {
        if (err) throw err;
        var dbo = db.db("DarkUnity");
        dbo.collection("usuarios").deleteOne({_id:code}, (err, result) => {
            if (err) throw err;
            console.log(result);
            db.close();
        });
    });
    res.end();
}