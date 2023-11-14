using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Tiempo : MonoBehaviour
{


    // variable TextMeshProUGUI para el gameOverText
    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI timeText;
        // variable GameObject para titleScreen  
    public GameObject titleScreen;

       // button
    public Button restartButton; 

        // variable booleana para saber si el juego es activo
    public bool isGameActive;

    static float tiempo;
    public float gameDuration = 90.0f; // Duracion del juego en segundos (2 minutos)


//al inicia el juego se quita el titulo y reiniciara la puntuacion y ajusta el spawn
    public void StartGame()
    {

        isGameActive = true;
        tiempo = 0f;
        titleScreen.SetActive(false);
       
       
    }

    // Update is called once per frame
    void Update()
    {
            if (tiempo < gameDuration)
        {
            tiempo += Time.deltaTime;

            int minutes = Mathf.FloorToInt(tiempo / 60);
            int seconds = Mathf.FloorToInt(tiempo - minutes * 60);

            string time = string.Format("{0:0}:{1:00}", minutes, seconds);

            timeText.text = time;
        }
        else
        {
            // El tiempo ha terminado, aqu� puedes mostrar el panel GameOverScreen y pausar el juego.
            titleScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

        public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // reinicia  el juego
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
