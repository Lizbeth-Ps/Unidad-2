//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using MongoDB.Driver;
//using MongoDB.Bson;

//public class DatabaseMongo : MonoBehaviour
//{
//    private MongoClient client;
//    private IMongoDatabase database;
//    private IMongoCollection<BsonDocument> collection; // Cambié "scoresCollection" a "collection".

//    private void Start()
//    {
//        client = new MongoClient("mongodb+srv://unity:unity@cluster0.9m01ii5.mongodb.net/?retryWrites=true&w=majority");
//        database = client.GetDatabase("Unity");
//        collection = database.GetCollection<BsonDocument>("player");
//    }

//    public void SaveScore(string playerName, int playerScore)
//    {


//        var scoreDocument = new BsonDocument
//        {
//            { "playerName", playerName },
//            { "score", playerScore }
//        };

//        collection.InsertOne(scoreDocument);
//    }
//}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class DatabaseMongo : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

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

    // Nuevo método para obtener las mejores puntuaciones
    public List<ScoreData> GetTopScores(int count)
    {
        var filter = Builders<BsonDocument>.Filter.Empty;
        var sort = Builders<BsonDocument>.Sort.Descending("score");
        var result = collection.Find(filter).Sort(sort).Limit(count).ToList();

        List<ScoreData> topScores = new List<ScoreData>();

        foreach (var bson in result)
        {
            string playerName = bson["playerName"].AsString;
            int score = bson["score"].AsInt32;
            ScoreData scoreData = new ScoreData(playerName, score);
            topScores.Add(scoreData);
        }

        return topScores;
    }

}

