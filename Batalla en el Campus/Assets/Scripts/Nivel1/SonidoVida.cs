using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoVida : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Samanta"))
        {
            // Verifica si el AudioSource está habilitado
            if (audioSource != null && audioSource.enabled)
            {
                audioSource.Play();
            }
        }
    }
}
