using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using MongoDB.Driver;
using MongoDB.Bson;

public class script_finalResult : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    public TextMeshProUGUI totalResult;
    // Start is called before the first frame update
    void Start()
    {
        float total = script_textControl.instance.nota;
        double percentage = Math.Round((total * 100) / 20, 2);
        totalResult.text = "Puntuación obtenida: " + percentage.ToString() + "%";

        InitConnection();
        InsertData(percentage.ToString() + "%");
    }

    private void InitConnection()
    {
        string connectionString = "mongodb+srv://BryanORCc:Rhythm1235@cluster.naaa8iz.mongodb.net/?retryWrites=true&w=majority";
        client = new MongoClient(connectionString);
        database = client.GetDatabase("Game");

        // Obtener una referencia a la colección
        collection = database.GetCollection<BsonDocument>("users");
    }

    private void InsertData(string note)
    {
        string name = PlayerPrefs.GetString("Name");
        var document = new BsonDocument
        {
            {"name", name },
            { "note", note }
        };

        collection.InsertOne(document);

        Debug.Log("Documento insertado en la colección.");
    }
}
