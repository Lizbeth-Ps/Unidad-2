using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoButones : MonoBehaviour
{
    public Button button; // Asigna el botón desde el Inspector.
    public AudioSource audioSource; // Asigna el AudioSource desde el Inspector.

    private void Start()
    {
        // Asegúrate de que el botón y el AudioSource estén asignados.
        if (button != null && audioSource != null)
        {
            // Asigna la función al evento de clic del botón.
            button.onClick.AddListener(PlayButtonClickSound);
        }
        else
        {
            Debug.LogWarning("Button or AudioSource not assigned.");
        }
    }

    // Función para reproducir el sonido cuando se hace clic en el botón.
    private void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}
