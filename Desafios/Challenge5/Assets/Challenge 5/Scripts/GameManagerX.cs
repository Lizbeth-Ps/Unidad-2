using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    // variable TextMeshProUGUI para el  scoreText
    public TextMeshProUGUI scoreText;

    // variable TextMeshProUGUI para el gameOverText
    public TextMeshProUGUI gameOverText;

    // variable TextMeshProUGUI para el timeText
    public TextMeshProUGUI timeText;

    // variable GameObject para titleScreen  
    public GameObject titleScreen;
   
   // button
    public Button restartButton; 

    //lista de GameObject
    public List<GameObject> targetPrefabs;

    // variable float para el tiempo
    private float timeValue;

    //variable int para el score
    private int score;

    //  variable float para el tiempo de spawn
    private float spawnRate = 1.5f;

    // variable booleana para saber si el juego es activo
    public bool isGameActive;

    //variable float en 2.5f 
    private float spaceBetweenSquares = 2.5f; 
    
    // variable float en -3.75f
    private float minValueX = -3.75f;

    // variable float en  -3.75f
    private float minValueY = -3.75f;
    
    //al inicia el juego se quita el titulo y reiniciara la puntuacion y ajusta el spawn
    public void StartGame(int difficulty)
    {
        //cambia valor a la dificultad 
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        timeValue = 60;
        UpdateScore(0);
        titleScreen.SetActive(false);
       
       
    }

    //cuando el juego este activo se deben de generar los objetos
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
        //validacion si el juego esta activo hacen spawn lo objetos
            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
            
        }
    }

    // posision random de spawn de objetos
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // actualiza score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    
    // se verifica si el juego es activo para seguir disminuyendo el tiempo, caso contrario termina
    public void Update()
    {
       if(isGameActive == true){
           TimeLeft();
       }
       if( timeValue < 0){
           GameOver();
       }
    }

    // tiempo restante
    public void TimeLeft() 
    {
    timeValue -= Time.deltaTime;
    timeText.text = "Tiempo : " + Mathf.Round(timeValue);
    }

    // terminar juego
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
