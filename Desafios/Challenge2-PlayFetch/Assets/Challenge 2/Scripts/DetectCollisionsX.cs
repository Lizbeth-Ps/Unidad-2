

// Importaciones
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisionsX : MonoBehaviour
{
    // Funcion que ayuda a destruir los objetos tanto perro como pelota
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
