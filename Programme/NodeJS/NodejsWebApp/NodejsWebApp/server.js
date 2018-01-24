var http = require('http');
var url = require('url');
var bodyParser = require('body-parser');
var MongoClient = require('mongodb').MongoClient;
var express = require('express');

var app = express();

var database = "HLWDB";

var productCollection = "Produkte";
var transCollection = "Transaktionen";
var userCollection = "User";
var warehouseCollection = "Lager";

var user = "admin";
var psw = "2OMWwM8lYJ6yJITc";
var uri = "mongodb://" + user + ":" + psw + "@cluster0-shard-00-00-xguqy.mongodb.net:27017,cluster0-shard-00-01-xguqy.mongodb.net:27017,cluster0-shard-00-02-xguqy.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";

var port = process.env.port || 1337;
console.log("Running on port: " + port);

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
  });
  
app.get('/', function (req, res) {
    res.send("NodeJS WebService with MongoDB");
    res.end(200);
});

/* ---------- Read ---------- */
app.get('/readWarehouse', function (req, res) {
    read(res, warehouseCollection);
});

app.get('/readProduct', function (req, res) {
    read(res, productCollection);
});

app.get('/readTrans', function (req, res) {
    read(res, transCollection);
});
/* ---------- Read end ---------- */

/* ---------- Add ---------- */
app.post('/addProduct', function (req, res) {
    create(req, res, productCollection);
});

app.post('/addWarehouseItem', function (req, res) {
    create(req, res, warehouseCollection);
});

app.post('/addTrans', function (req, res) {
    create(req, res, transCollection);
});
/* ---------- Read end ---------- */

/* ---------- Update ---------- */
app.put('/updateWarehouseItem', function (req, res) {
    update(req, res, warehouseCollection);
});

app.put('/updateProduct', function (req, res) {
    update(req, res, productCollection);
});
/* ---------- Update end ---------- */

/* ---------- Delete ---------- */
app.post('/deleteWarehouseItem', function (req, res) {
    remove(req, res, warehouseCollection);
});

app.post('/deleteProduct', function (req, res) {
    remove(req, res, productCollection);
});
/* ---------- Delete end ---------- */

app.post('/user', function (req, res) {
    userLogin(req, res, userCollection);
});

app.listen(port);

function read(res, collection) {
    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {

            var db = client.db(database);
            db.collection(collection).find({}).toArray(function (err, result) {
                if (err) {
                    res.send(err);
                    res.end(400);
                } else {
                    res.send(result);
                    res.end(200);
                }
            });
            client.close();
        }
    });
}

function userLogin(req, res, collection) {
    var json = req.body;
    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {
            var db = client.db(database);
            
            db.collection(collection).findOne(json, function (err, result) {
                if (err) {
                    res.status(400).send(err);
                } else if(result == null) {
                    res.status(401.1).send("No entries found!");
                } else if (result.email == null || result.passwort == null) {
                    res.status(401.2).send("Result and/or email is empty!");
                } else if(rightCredentials(result, json)) {
                    res.status(200).send({"state" : "succesful", json});
                } else {
                    res.status(404).send("Request failed!");
                }
            });

            client.close();
        }
    });
}

function rightCredentials(result, jsonCheck) {
    return (result.email == jsonCheck.email) && (result.passwort == jsonCheck.passwort);
}

function create(req, res, collection) {
    var jsonInsert = req.body;
    
    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {
            var db = client.db(database);

            db.collection(collection).insertOne(jsonInsert, function (err, result) {
                if (err) {
                    res.send(err);
                    res.end(400);
                } else {
                    res.send("Inserted 1 document");
                    res.end(200);
                }
            });
            client.close();
        }
    });
}

function update(req, res, collection) {
    var myquery = req.body;
    var sourceValues = myquery[0].source;
    var newValues = myquery[0].destination;

    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {
            var db = client.db(database);

            db.collection(collection).updateOne(sourceValues, newValues /*{ name: sourceValues.name }, { $set: newValues }*/, function (err, dbresp) {
                if (err) {
                    res.send(err);
                    res.end(400);
                } else {
                    res.send("1 document updated");
                    res.end(200);
                }
            });
            client.close();
        }
    });
}

function remove(req, res, collection) {
    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {

            var db = client.db(database);
            var myquery = req.body;

            db.collection(collection).deleteOne(myquery, function (err, obj) {
                if (err) {
                    res.send(err);
                    res.end(400);
                } else {
                    res.send("1 document deleted");
                    res.end(200);
                }
            });
            client.close();
        }
    });
}