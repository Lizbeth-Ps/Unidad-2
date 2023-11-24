using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Samanta"))
        {
            audioSource.Play();
        
        }
    }       
}
