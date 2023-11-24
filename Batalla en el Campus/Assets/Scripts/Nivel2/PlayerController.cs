using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 30.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    public GameObject gameWin; // Panel GameWin

    // SONIDO PASOS PERSONAJE  
    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;

    //REGLA CGTI
    private bool haPasadoPorCGTI = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // Asegúrate de desactivar el objeto gameWin al inicio del juego
        if (gameWin != null)
        {
            gameWin.SetActive(false);
        }
        else
        {
            //Debug.LogError("El objeto gameWin no está asignado en el Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (Input.GetButtonDown("Horizontal"))
        {

            if (Vactivo == false)
            {
                Hactivo = true;
                pasos.Play();
            }

        }
        if (Input.GetButtonDown("Vertical"))
        {

            if (Hactivo == false)
            {
                Vactivo = true;
                pasos.Play();
            }

        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();
            }

        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ganador") && haPasadoPorCGTI)
        {
            //Debug.Log("Colisionando con el ganador");
            MostrarPantallaFelicitaciones();
            //SceneManager.LoadScene("Nivel2");
        }
        else if (other.CompareTag("CGTI"))
        {
            //Debug.Log("Colisionando con el edificio CGTI");
            haPasadoPorCGTI = true;
        }
    }

    void MostrarPantallaFelicitaciones()
    {
        if (gameWin != null)
        {
            gameWin.SetActive(true);
            Time.timeScale = 0.0f; // Detener el juego
        }
        else
        {
            //Debug.LogError("El objeto gameWin no está asignado en el Inspector.");
        }
    }

}