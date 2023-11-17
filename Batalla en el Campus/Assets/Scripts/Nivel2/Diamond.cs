using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public string objectName; // Asigna el nombre del objeto aquí.
    private int objectScore = 0; // Inicializa el valor en puntos en 0;


    private PlayerInventory playerInventory;
    private ScoreManager scoreManager;
    private InventoryUI inventoryUI;
    private DatabaseMongo databaseMongo;

    private void Start()
    {

        // Asignar las referencias directas en el método Start.
        playerInventory = FindObjectOfType<PlayerInventory>();
        scoreManager = FindObjectOfType<ScoreManager>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        databaseMongo = FindObjectOfType<DatabaseMongo>();

        // Agregar nombres y valores de objetos.
        if (objectName == "Calculator") objectScore = 30;
        else if (objectName == "Borrador") objectScore = 50;
        else if (objectName == "Tijeras") objectScore = 80;
        else if (objectName == "NotasAmarillas") objectScore = 55;
        else if (objectName == "NotasAzules") objectScore = 60;

    }

    private void OnTriggerEnter(Collider other)
    {
        //PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
         

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
                    //string playerName = "PlayerName"; // Reemplaza con el nombre del jugador o algún identificador único
                    //databaseMongo.SaveScore(playerName, scoreManager.GetPlayerScore());

                    // Obtener el nombre del jugador desde MenuManager
                    string playerName = MenuManager.nombreJugador;

                    // Asegúrate de que el nombre del jugador no sea nulo o vacío antes de guardarlo
                    if (!string.IsNullOrEmpty(playerName))
                    {
                        int playerScore = scoreManager.GetPlayerScore();
                        databaseMongo.SaveScore(playerName, playerScore);
                    }
                    else
                    {
                        Debug.LogError("El nombre del jugador es nulo o vacío.");
                    }
                }
            
            }
            //gameObject.SetActive(false);
        }
    }
}
