using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Reglas")]
     [Header("Panels")]

     public GameObject panelMenu;
     public GameObject reglasPanel;
    public GameObject ordenesPanel;
    public GameObject historiaPanel;
    public GameObject panelNombre;

    //INPUT NOMBRE 
    public InputField inputText;

    public Text textoNombre;
    public Image luz;

    public GameObject buttonAceptar;

    //COMENZAR JUEGO 
    public void ComenzarJuego(){
        
        PlayerPrefs.SetString("nombre1", inputText.text);
        SceneManager.LoadScene("Nivel2");
    }

    public void OpenPanel(GameObject panel){
        panelMenu.SetActive(false);
        reglasPanel.SetActive(false);
        ordenesPanel.SetActive(false);
       historiaPanel.SetActive(false);
       panelNombre.SetActive(false);

        panel.SetActive(true);
    }

    private void Awake(){
        luz.color = Color.red;
    }

    public void Update(){
        if(textoNombre.text.Length < 4){
            luz.color = Color.red;
            buttonAceptar.SetActive(false);
        }

         if(textoNombre.text.Length >= 4){
            luz.color = Color.green;
             buttonAceptar.SetActive(true);
        }
    }



}
