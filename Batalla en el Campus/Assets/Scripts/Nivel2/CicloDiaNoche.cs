using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    public int rotationScale =10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
    }
}
