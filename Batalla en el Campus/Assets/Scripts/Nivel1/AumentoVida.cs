using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoVida : MonoBehaviour
{
    public BarraVida barraVida;
    public int aumentoDeVida = 1;

    // Se llama cuando otro collider entra en contacto con este collider (trigger)
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Samanta"))
    //    {
    //        // Verifica si la vida actual es menor que la vida máxima antes de aumentarla
    //        if (barraVida.vidaActual < barraVida.vidaMax)
    //        {
    //            // Incrementa la vida de Samanta
    //            barraVida.vidaActual += aumentoDeVida;

    //            // Desactiva el objeto (o haz cualquier otra cosa que necesites)
    //            gameObject.SetActive(false);
    //            //Destroy(gameObject);
    //        }
    //    }
    //}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected!");  // Verifica si se detecta la colisión

        if (other.CompareTag("Samanta"))
        {
            Debug.Log("Samanta collided!");  // Verifica si la etiqueta es correcta

            // Verifica si la vida actual es menor que la vida máxima antes de aumentarla
            if (barraVida.vidaActual < barraVida.vidaMax)
            {
                Debug.Log("Increasing life!");  // Verifica si la vida se está incrementando

                // Incrementa la vida de Samanta
                barraVida.vidaActual += aumentoDeVida;

                // Destruye el objeto en lugar de desactivarlo
                Destroy(gameObject);
            }
        }
    }

}
