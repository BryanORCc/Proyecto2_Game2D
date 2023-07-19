using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;

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

    private string GetMongoDBConnectionString()
    {
        TextAsset resourceFile = Resources.Load<TextAsset>("mongodb_connection");

        string filePath = resourceFile.text.Trim();

        string connectionString = string.Empty;

        if (filePath != "")
        {
            connectionString = filePath;
        }

        return connectionString;
    }

    private void InitConnection()
    {
        string connectionString = GetMongoDBConnectionString();

        if (!string.IsNullOrEmpty(connectionString))
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("Game");

            // Obtener una referencia a la colección
            collection = database.GetCollection<BsonDocument>("users");
        }
        else
        {
            Debug.LogError("No se encontró la cadena de conexión a MongoDB en el archivo de configuración.");
        }
    }

    private void InsertData(string note)
    {
        string name = PlayerPrefs.GetString("Name");
        string grade = PlayerPrefs.GetString("Grade");
        string subject = PlayerPrefs.GetString("Subject");
        var document = new BsonDocument
        {
            {"nombre", name },
            {"grado", grade},
            {"tema", subject},
            { "nota", note }
        };

        collection.InsertOne(document);

        Debug.Log("Documento insertado en la colección.");
    }
}
