using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersistente : MonoBehaviour
{

     private static AudioPersistente instance;
    // Start is called before the first frame update
    
     void Awake()
    {
        // Verifica si ya existe una instancia del objeto persistente
        if (instance == null)
        {
            // Si no hay instancia, haz que este objeto sea la instancia persistente
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya hay una instancia, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

