using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersistente : MonoBehaviour
{
    private static AudioPersistente instance;
    private AudioSource audioSource;

    public AudioClip sonidoInicio;
    public AudioClip sonidoNivel;
    public AudioClip sonidoNivel2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Reproduce el sonido de inicio al comenzar
        ReproducirSonidoInicio();
    }

    public void ReproducirSonidoInicio()
    {
        audioSource.clip = sonidoInicio;
        audioSource.Play();
    }

    public void ReproducirSonidoNivel()
    {
        audioSource.clip = sonidoNivel;
        audioSource.Play();
    }

    public void ReproducirSonidoNivel2()
    {
        audioSource.clip = sonidoNivel2;
        audioSource.Play();
    }

    public void DetenerSonido()
    {
        audioSource.Stop();
    }

    // Nuevo método para reiniciar el audio
    public void ReiniciarSonido()
    {
        // Detén el sonido antes de reiniciar
        DetenerSonido();
        // Reproduce el sonido de inicio después de detenerlo
        ReproducirSonidoInicio();
    }
}
