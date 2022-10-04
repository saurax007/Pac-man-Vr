using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private Transform target;
    float m_Speed;
    float m_Grados;
    bool try_Turn;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 5.0f; // Ajustar
        m_Grados = 0;
        try_Turn = false;
    }

    void Update()
    {
        MoveForward();

        if (try_Turn)
        {
            Girar(m_Grados);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            try_Turn = Girar(180);           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            try_Turn = Girar(90);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            try_Turn = Girar(-90);
        }
    }

    private void MoveForward() {
        // Movimiento Constante 2 modos

        //m_Rigidbody.velocity = transform.forward * m_Speed;
        transform.position += Vector3.forward * Time.deltaTime * m_Speed;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }


    private bool Girar(float grados)
    {
        // si en la direccion indicada puede girar devolvemos true y ponemos el flag a false
        // si no lo intentamos nuevamente hasta que giremos
        m_Grados = grados;
        if (true)
        {
            transform.Rotate(new Vector3(0, grados, 0), Space.World);
            ResetCam();
            return false;
        }
        return true;
    }



    private void TargetUpdate()
    {
        // ACTUALIZAR TARGET 

        //TODO
    }

    private void ResetCam()
    {
        // alineamos la camara y la direccion del jugador

        //TODO
    }
}
