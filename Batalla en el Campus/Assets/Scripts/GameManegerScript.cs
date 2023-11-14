using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerScript : MonoBehaviour
{
    public void RestartGame()
    {
        // Carga la escena actual nuevamente para reiniciar el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        // Carga la escena del men� principal. Aseg�rate de que el nombre de la escena sea correcto.
        SceneManager.LoadScene("Menu");
    }

    public void QuitToLevel1()
    {
        // Carga la escena "Nivel1" cuando el jugador quiera salir.
        SceneManager.LoadScene("Nivel1");
    }
}
