using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BarraVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;


    public GameObject gameOverScreen; // Panel GameOverScreen
    // Start is called before the first frame update
    void Start()
    {
        //vidaActual = vidaMax;
        InicializarJuego();

    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if (vidaActual == 0)
        {
            // gameObject.SetActive(false);
            MostrarGameOver();


            // Busca una instancia de AudioPersistente y detén el sonido si se encuentra
            AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
            if (audioPersistente != null)
            {
                audioPersistente.DetenerSonido();
            }
        }
    }
    public void InicializarJuego()
    {
        vidaActual = vidaMax;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1.0f; // Asegúrate de que el tiempo esté en su velocidad normal al iniciar
    }

    public void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }

    void DetenerJuego()
    {
        Time.timeScale = 0.0f; // Detiene el tiempo
    }

    public void MostrarGameOver()
    {
        gameOverScreen.SetActive(true);
        DetenerJuego();
    }

    public void ReiniciarJuego()
    {
        // Aquí reinicias todo lo necesario para reiniciar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Esto reinicia la escena actual
        InicializarJuego(); // Asegúrate de que la inicialización se realice después de cargar la escena
    }
}

