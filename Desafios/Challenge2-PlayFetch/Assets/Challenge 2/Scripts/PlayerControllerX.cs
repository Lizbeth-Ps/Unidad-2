
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Clase PlayerControllerX da soporte  al player a crear varios objetos tipo perro.
**/
public class PlayerControllerX : MonoBehaviour
{
    // variable GameObject
    public GameObject dogPrefab;

    //VARIABLES PARA LA BONIFICACION QUE ES EL TIEMPO DE ESPERA PARA LANZAR UN PERRO 
    private float tiempoEspera = 1;
    private float tiempoSiguienteDisparo = 0;

    // Update is called once per frame
    void Update()
    {

        // Al presionar la tecla espacio en el teclado  creara un objeto de tipo perro
        if (Input.GetKeyDown(KeyCode.Space)  && Time.time > tiempoSiguienteDisparo)

        {
            tiempoSiguienteDisparo = Time.time + tiempoEspera;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
        
    }
}
