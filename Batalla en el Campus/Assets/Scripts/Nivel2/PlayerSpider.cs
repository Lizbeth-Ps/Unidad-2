using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpider : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaLimite = 20f;
    public float tiempoDeCambioDeDireccion = 2f;

    private Vector3 posicionInicial;
    private float tiempoPasado;
    private int direccion = 1;  // 1 para derecha, -1 para izquierda

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        MoverEnemigo();
    }

    void MoverEnemigo()
    {
        tiempoPasado += Time.deltaTime;

        // Calcular la nueva posición usando Lerp
        float factorLerp = Mathf.PingPong(tiempoPasado / tiempoDeCambioDeDireccion, 1f);
        float nuevaPosicionX = Mathf.Lerp(posicionInicial.x - distanciaLimite, posicionInicial.x + distanciaLimite, factorLerp);

        // Establecer la posición
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        // Si llega al límite izquierdo, invertir la dirección
        if (Mathf.Approximately(factorLerp, 0f))
        {
            CambiarDireccion();
        }
    }

    void CambiarDireccion()
    {
        // Invertir la dirección
        direccion *= -1;
        // Ajustar la posición inicial para evitar un salto en la interpolación
        posicionInicial = transform.position;
    }

}

