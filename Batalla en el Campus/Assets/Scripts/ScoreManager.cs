using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0; // Puntaje inicial del jugador

    private void Start()
    {
        // Configura el puntaje inicial si es necesario.
        playerScore = 0;
    }

    public void IncreaseScore(int points)
    {
        playerScore += points;
        // Aqu� puedes actualizar tu interfaz de usuario para mostrar el puntaje actual.
    }

    // Agrega un m�todo para obtener el puntaje del jugador.
    public int GetPlayerScore()
    {
        return playerScore;
    }
}
