using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public BarraVida barraVida;
    public float daño = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Se llama cuando otro collider entra en contacto con este collider (trigger)
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que ha entrado en el trigger tiene la etiqueta "Samanta"
        if (other.CompareTag("Samanta"))
        {
            // Reduce la vida de Samanta
            barraVida.vidaActual -= daño;
        }
    }
}
