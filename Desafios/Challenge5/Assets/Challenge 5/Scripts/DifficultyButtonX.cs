using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{

    // button 
    private Button button;

    //script GameManagerX
    private GameManagerX gameManagerX;

    // variable int difficulty 
    public int difficulty;


    // al empezar
    void Start()
    {

        // se busca Game Manager
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        button = GetComponent<Button>();
        // se le aplica un listener
        button.onClick.AddListener(SetDifficulty);
    }

    // se aplica dificultad
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManagerX.StartGame(difficulty);
    }



}
