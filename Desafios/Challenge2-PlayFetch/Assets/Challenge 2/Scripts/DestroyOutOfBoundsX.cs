
// Importaciones
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{

    // Variable tipo float que guarda el limite del juego del lado izquierdo
    private float leftLimit = -40;

    // Variable tipo float que guarda el limite del juego del lado del suelo
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {


        // Validacion que destruye perros si la posición del mismo  es inferior al límite izquierdo
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 


        // Validacion que destruye las bolas si la posición de la misma es menor que bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
