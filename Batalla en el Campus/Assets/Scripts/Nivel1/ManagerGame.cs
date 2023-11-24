using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public Timer timerScript; // Referencia al script del temporizador
    public BarraVida barraVidaScript;

    void Start()
    {
        // Obtén la referencia al script del temporizador al inicio
        timerScript = FindObjectOfType<Timer>();
        barraVidaScript = FindObjectOfType<BarraVida>();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f; // Asegúrate de restablecer la escala del tiempo
        // Reinicia el temporizador antes de cargar la escena
        timerScript.RestartTimer();
        barraVidaScript.InicializarJuego();

        // Encuentra la instancia actual de AudioPersistente
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();

        if (audioPersistente != null)
        {
            // Detén el sonido antes de destruir la instancia actual
            audioPersistente.DetenerSonido();
            // Reinicia el audio antes de destruir la instancia actual
            audioPersistente.ReiniciarSonido();
            // Destruye la instancia actual de AudioPersistente antes de cargar un nuevo nivel
            Destroy(audioPersistente.gameObject);
        }

        // Carga la escena actual para reiniciar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f; // Asegúrate de restablecer la escala del tiempo

        // Reinicia el temporizador antes de cargar la escena
        timerScript.RestartTimer();
        

        // Destruye la instancia de AudioPersistente antes de cargar un nuevo nivel
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
        if (audioPersistente != null)
        {
            // Utiliza Destroy para destruir la instancia
            Destroy(audioPersistente.gameObject);
        }

        SceneManager.LoadScene("PInicio");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Nivel1Return()
    {
        Time.timeScale = 1.0f; // Asegúrate de restablecer la escala del tiempo

        // Reinicia el temporizador antes de cargar la escena
        timerScript.RestartTimer();

        // Destruye la instancia de AudioPersistente antes de cargar un nuevo nivel
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
        if (audioPersistente != null)
        {
            // Utiliza Destroy para destruir la instancia
            Destroy(audioPersistente.gameObject);
        }

        // Carga la escena "Nivel1" cuando el jugador quiera salir.
        SceneManager.LoadScene("Nivel1");
    }



    public void Nivel2Return()
    {
        Time.timeScale = 1.0f; // Asegúrate de restablecer la escala del tiempo

        // Reinicia el temporizador antes de cargar la escena
        timerScript.RestartTimer();

        // Destruye la instancia de AudioPersistente antes de cargar un nuevo nivel
        AudioPersistente audioPersistente = FindObjectOfType<AudioPersistente>();
        if (audioPersistente != null)
        {
            // Utiliza Destroy para destruir la instancia
            Destroy(audioPersistente.gameObject);
        }

        // Carga la escena "Nivel1" cuando el jugador quiera salir.
        SceneManager.LoadScene("Nivel2");
    }
}
