using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerGame : MonoBehaviour
{

    public Timer timerScript; // Referencia al script del temporizador

    void Start()
    {
        // Obtén la referencia al script del temporizador al inicio
        timerScript = FindObjectOfType<Timer>();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f; // Asegúrate de restablecer la escala del tiempo

        // Reinicia el temporizador antes de cargar la escena
        timerScript.RestartTimer();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("PInicio");
    }

    public void SalirJuego(){
        Application.Quit();
    }

    public void Nivel1Return()
    {
        // Carga la escena "Nivel1" cuando el jugador quiera salir.
        SceneManager.LoadScene("Nivel1");
    }


}
