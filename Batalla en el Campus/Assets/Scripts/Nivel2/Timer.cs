using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    static float timer;
    public float gameDuration = 120.0f; // Duración del juego en segundos (2 minutos)
    public GameObject gameOverScreen; // Panel GameOverScreen

    void Start()
    {
        timer = 0f; // Inicializa el contador de tiempo en cero al comienzo del juego
        // Asegúrate de que el panel GameOverScreen esté desactivado al inicio del juego
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (timer < gameDuration)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);

            string time = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = time;
        }
        else
        {
            // El tiempo ha terminado, aquí puedes mostrar el panel GameOverScreen y pausar el juego.
            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
