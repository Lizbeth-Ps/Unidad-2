using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class BestScoresPanel : MonoBehaviour
{
    public Text scoreText; // Asegúrate de haber asignado el objeto Text en el Inspector.
    public DatabaseMongo database; // Asegúrate de haber asignado el componente DatabaseMongo en el Inspector.

    void Start()
    {
        // Obtén las mejores puntuaciones desde la base de datos.
        List<ScoreData> topScores = database.GetTopScores(5);

        Debug.Log($"Número de puntuaciones obtenidas: {topScores.Count}");

        // Actualiza el texto en el panel con las mejores puntuaciones.
        UpdateScoresText(topScores);
    }

    // Función para actualizar el texto con las mejores puntuaciones.
    //void UpdateScoresText(List<ScoreData> scores)
    //{
    //    // Verifica si se ha asignado el objeto Text.
    //    if (scoreText != null)
    //    {
    //        // Limpia el texto existente.
    //        scoreText.text = "";

    //        // Itera a través de las puntuaciones y agrega la información al texto.
    //        for (int i = 0; i < scores.Count; i++)
    //        {
    //            ScoreData score = scores[i];
    //            scoreText.text += $"{i + 1}. {score.playerName}: {score.score}\n";
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Text component not assigned in the Inspector.");
    //    }
    //}
    void UpdateScoresText(List<ScoreData> scores)
    {
        // Verifica si se ha asignado el objeto Text.
        if (scoreText != null)
        {
            // Crea un StringBuilder para construir el texto.
            StringBuilder sb = new StringBuilder();

            // Itera a través de las puntuaciones y agrega la información al StringBuilder.
            for (int i = 0; i < scores.Count; i++)
            {
                ScoreData score = scores[i];
                sb.AppendLine($"{i + 1}. {score.playerName}: {score.score}");
            }

            // Asigna el texto construido al Text.
            scoreText.text = sb.ToString();
        }
        else
        {
            Debug.LogError("Text component not assigned in the Inspector.");
        }
    }
}
