using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    static float timer;
    public float gameDuration = 120.0f;
    public GameObject gameOverScreen;

    private bool isGameOver = false;
    public BarraVida barraVidaScript;

    void Start()
    {
        timer = 0f;
        gameOverScreen.SetActive(false);
        // Al iniciar el temporizador, cambia el sonido al del nivel
        ReproducirSonidoNivel();
        barraVidaScript = FindObjectOfType<BarraVida>();

    }

    void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);

            string time = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = time;

            if (timer >= gameDuration)
            {
                isGameOver = true;
                // El tiempo ha terminado, aquí puedes mostrar el panel GameOverScreen y pausar el juego.
                gameOverScreen.SetActive(true);
                Time.timeScale = 0.0f;

                // Detener el sonido al finalizar el tiempo
                DetenerSonido();
            }
        }
    }

    public void RestartTimer()
    {
        timer = 0f;
        isGameOver = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1.0f;
        // Al reiniciar el temporizador, cambia el sonido al del nivel
        ReproducirSonidoNivel();
    }

    // Métodos para reproducir y detener el sonido
    void ReproducirSonidoNivel()
    {
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
        if (audioPersistente != null)
        {
            audioPersistente.ReproducirSonidoNivel();
        }
    }

    void DetenerSonido()
    {
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
        if (audioPersistente != null)
        {
            audioPersistente.DetenerSonido();
        }
    }
}
