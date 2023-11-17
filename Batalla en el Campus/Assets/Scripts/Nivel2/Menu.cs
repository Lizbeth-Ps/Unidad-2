using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void LoadNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void Salir()
    {
        Application.Quit();
    }

}
