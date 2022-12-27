using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Data;
using Npgsql;

public class CreateDatabasw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //addTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTable()
    {
        // Connect to the database
        var connectionString = "Server=bysehjl0nr1jzotn0tad-postgresql.services.clever-cloud.com; Port=5432; UId = uqyv8q8w70nukc7e9tlw; Password=NDQcvPXJ3dxH4nLqLWl8; Database=bysehjl0nr1jzotn0tad;";
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = "CREATE TABLE Detai(gmail VARCHAR(100), password BYTEA)";
        command.ExecuteNonQuery();
        Debug.Log("CREATED");
    }
}
