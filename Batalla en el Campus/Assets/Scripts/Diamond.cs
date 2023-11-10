using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public string objectName; // Asigna el nombre del objeto aquí.
    private int objectScore = 0; // Inicializa el valor en puntos en 0;

    private void Start()
    {



        // Agrega los nombres de los objetos y sus respectivos valores en puntos.
        if (objectName == "Calculator") objectScore = 30;
        else if (objectName == "Borrador") objectScore = 50;
        else if (objectName == "Tijeras") objectScore = 80;
        else if (objectName == "NotasAmarillas") objectScore = 55;
        else if (objectName == "NotasAzules") objectScore = 60;
        // Puedes agregar más objetos y sus puntajes según sea necesario.
        Debug.Log("Diamond Start() is called. ObjectName: " + objectName);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(objectScore);
                InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
                if (inventoryUI != null)
                {
                    inventoryUI.UpdateScoreText(scoreManager.GetPlayerScore());
                }

                DatabaseMongo databaseMongo = FindObjectOfType<DatabaseMongo>();
                if (databaseMongo != null)
                {
                    string playerName = "PlayerName"; // Reemplaza con el nombre del jugador o algún identificador único
                    databaseMongo.SaveScore(playerName, scoreManager.GetPlayerScore());
                }
            }
            gameObject.SetActive(false);
        }
    }
}
