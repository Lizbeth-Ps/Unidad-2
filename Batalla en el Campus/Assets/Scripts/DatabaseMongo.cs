using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class DatabaseMongo : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection; // Cambié "scoresCollection" a "collection".

    private void Start()
    {
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.9m01ii5.mongodb.net/?retryWrites=true&w=majority");
        database = client.GetDatabase("Unity");
        collection = database.GetCollection<BsonDocument>("player");
    }

    public void SaveScore(string playerName, int playerScore)
    {
        var scoreDocument = new BsonDocument
        {
            { "playerName", playerName },
            { "score", playerScore }
        };

        collection.InsertOne(scoreDocument);
    }
}
