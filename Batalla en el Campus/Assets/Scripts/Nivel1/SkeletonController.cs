using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{

 public float velocidadCaminar = 5f;
    public float velocidadCorrer = 10f;
    public float fuerzaSalto = 10f;
    public float velocidadGiro = 100f;

    private bool enSuelo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el personaje está en el suelo
        enSuelo = Physics.Raycast(transform.position, Vector3.down, 0.2f);

        // Movimiento y salto
        Mover();
        Saltar();
    }

    void Mover()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Rotación del personaje
        transform.Rotate(Vector3.up * movimientoHorizontal * velocidadGiro * Time.deltaTime);

        // Movimiento hacia adelante y atrás
        Vector3 movimiento = new Vector3(0, 0, movimientoVertical);
        movimiento = transform.TransformDirection(movimiento);
        movimiento.y = 0f; // Mantener la posición Y constante

        // Aplicar velocidad
        if (Input.GetKey(KeyCode.LeftShift)) // Correr
        {
            rb.MovePosition(transform.position + movimiento * velocidadCorrer * Time.deltaTime);
        }
        else // Caminar
        {
            rb.MovePosition(transform.position + movimiento * velocidadCaminar * Time.deltaTime);
        }
    }

    void Saltar()
    {
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }
}