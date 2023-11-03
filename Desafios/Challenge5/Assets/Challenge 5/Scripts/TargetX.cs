using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetX : MonoBehaviour
{

    // componente Rigidbody 
    private Rigidbody rb;

    // script GameManagerX 
    private GameManagerX gameManagerX;

    // variable int pointValue
    public int pointValue;

    // variable GameObject 
    public GameObject explosionFx;
 
    // variable float en 1.0f
    public float timeOnScreen = 1.0f;

    // variable float minValueX en -3.75f
    private float minValueX = -3.75f;

    // variable  float  minValueY en -3.75f
    private float minValueY = -3.75f; 

    // variable float  spaceBetweenSquares en 2.5f
    private float spaceBetweenSquares = 2.5f;
    

    void Start()
    {
        // se obtiene el componente Rigidbody 
        rb = GetComponent<Rigidbody>();
        // se busca el Game Manager
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition(); 
        StartCoroutine(RemoveObjectRoutine());
    }

    
    private void OnMouseDown()
    {
    // validacion si el juego  es activo
        if (gameManagerX.isGameActive)
        {
            Destroy(gameObject);
            gameManagerX.UpdateScore(pointValue);
            Explode();
        }
               
    }

    Vector3 RandomSpawnPosition()
    {
        // spawneo aleatorio para ambas posiciones
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    int RandomSquareIndex ()
    {
        return Random.Range(0, 4);
    }


    private void OnTriggerEnter(Collider other)
    {
        // se destruye el objeto
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            gameManagerX.GameOver();
        } 

    }

    void Explode ()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }

    IEnumerator RemoveObjectRoutine ()
    {
        yield return new WaitForSeconds(timeOnScreen);
        if (gameManagerX.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }

    }

}
