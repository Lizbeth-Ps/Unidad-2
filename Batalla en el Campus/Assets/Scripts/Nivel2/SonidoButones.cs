using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoButones : MonoBehaviour
{
    public Button button; // Asigna el bot�n desde el Inspector.
    public AudioSource audioSource; // Asigna el AudioSource desde el Inspector.

    private void Start()
    {
        // Aseg�rate de que el bot�n y el AudioSource est�n asignados.
        if (button != null && audioSource != null)
        {
            // Asigna la funci�n al evento de clic del bot�n.
            button.onClick.AddListener(PlayButtonClickSound);
        }
        else
        {
            Debug.LogWarning("Button or AudioSource not assigned.");
        }
    }

    // Funci�n para reproducir el sonido cuando se hace clic en el bot�n.
    private void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}
