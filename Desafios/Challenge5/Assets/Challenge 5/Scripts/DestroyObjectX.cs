
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        //destruye el objeto en 3 segundos
        Destroy(gameObject, 3); 
    }


}
