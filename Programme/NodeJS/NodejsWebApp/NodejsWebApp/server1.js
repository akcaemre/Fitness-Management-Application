var http = require('http');
var url = require('url');
var MongoClient = require('mongodb').MongoClient;

var uri = "mongodb://admin:2OMWwM8lYJ6yJITc@cluster0-shard-00-00-xguqy.mongodb.net:27017,cluster0-shard-00-01-xguqy.mongodb.net:"
    + "27017,cluster0-shard-00-02-xguqy.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";
   // "mongodb+srv://admin:2OMWwM8lYJ6yJITc@cluster0-xguqy.mongodb.net/TestDB";
var port = process.env.port || 1337;
var collection = "MyFirstCollection";

MongoClient.connect(uri, function (err, client) {
    if (err) throw err;
    var db = client.db('TestDB');
    db.collection("MyFirstCollection").find({}).toArray(function (err, result) {
        if (err) throw err;
        console.log(result);
    });
    client.close();
});

http.createServer(function (req, res) {
    var redirect = req.url.split("?")[0];
    var response = "";
    var responseCode = 200;
    
    switch (redirect) {
        case "/create":
            response = create(url.parse(req.url, true).query);
            break;
        case "/read":
            response = read();
            break;
        case "/update":
            response = update();
            break;
        case "/delete":
            response = remove();
            break;
        default:
            response = "URL not found";
            responseCode = 404;
            break;
    }

    res.writeHead(responseCode, { 'Content-Type': 'text/plain' });
    res.end(response);
}).listen(port);

function read() {
    var response = "";

    MongoClient.connect(uri, function (err, client) {
        if (err) throw err;
        var db = client.db('TestDB');
        db.collection(collection).find({}).toArray(function (err, result) {
            if (err) throw err;
            response = result;
        });
        client.close();
    });

    return response;
}

function create(q) {
    var response = "";

    response = JSON.stringify(q);

    MongoClient.connect(uri, function (err, client) {
        if (err) throw err;
        var db = client.db('TestDB');
        db.collection(collection).insertOne(response, function (err, res) {
            if (err) throw err;
            console.log("1 document inserted");
        });
        client.close();
    });

    return response;
}