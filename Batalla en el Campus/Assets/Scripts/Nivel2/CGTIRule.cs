using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGTIRule : MonoBehaviour
{
    private bool samantaHaPasadoPorCGTI = false;

    // M�todo llamado cuando Samanta entra en el Collider del edificio CGTI
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Samanta") && !samantaHaPasadoPorCGTI)
        {
            Debug.Log("Samanta ha pasado por el edificio CGTI.");
            samantaHaPasadoPorCGTI = true;

            // Aqu� puedes realizar cualquier otra l�gica que necesites
        }
    }

    public void SamantaHaPasadoPorCGTI()
    {
        samantaHaPasadoPorCGTI = true;
    }
}
