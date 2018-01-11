var http = require('http');
var url = require('url');

var express = require('express');
var app = express();

var bodyParser = require('body-parser');

var MongoClient = require('mongodb').MongoClient;
var collection = "MyFirstCollection";
var database = "TestDB";
var user = "admin";
var psw = "2OMWwM8lYJ6yJITc";
var uri = "mongodb://" + user + ":" + psw + "@cluster0-shard-00-00-xguqy.mongodb.net:27017,cluster0-shard-00-01-xguqy.mongodb.net:27017,cluster0-shard-00-02-xguqy.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";

var port = process.env.port || 1337;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.get('/', function (req, res) {
    res.send("NodeJS WebService with MongoDB");
    res.end(200);
});

app.get('/read', function (req, res) {
    read(res, collection);
});

app.post('/create', function (req, res) {
    create(req, res, collection);
});

app.put('/update', function (req, res) {
    update(req, res, collection);
});

app.post('/delete', function (req, res) {
    remove(req, res, collection);
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
    MongoClient.connect(uri, function (err, client) {
        if (err) {
            res.send(err);
            res.end(400);
        } else {

            var db = client.db(database);
            var myquery = req.body;

            console.log("Body " + myquery);

            var sourceValues = myquery[0].source;
            var newValues = myquery[0].destination;

            db.collection(collection).updateOne(sourceValues, newValues, function (err, dbresp) {
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