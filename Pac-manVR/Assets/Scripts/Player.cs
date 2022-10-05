using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform raycaster;
    float m_stop_distance = 1.5f;
    float m_Speed;
    int m_direction;
    float m_Grados;
    bool try_Turn;

    void Start()
    {
        m_Speed = 1.0f; // Ajustar
        m_Grados = 0;
        try_Turn = false;
    }

    void Update()
    {
        if (this.CanMove())
        {
            MoveForward();
        }

        if (try_Turn)
        {
            try_Turn = Girar(m_Grados);
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
        switch (m_direction)
        {
            case 0:
                transform.position += Vector3.forward * Time.deltaTime * m_Speed;
                break;
            case 1:
                transform.position += Vector3.right * Time.deltaTime * m_Speed;
                break;
            case 2:
                transform.position += Vector3.back * Time.deltaTime * m_Speed;
                break;
            case 3:
                transform.position += Vector3.left * Time.deltaTime * m_Speed;
                break;
            default:
                break;
        }
    }


    private bool Girar(float grados)
    {
        // si en la direccion indicada puede girar devolvemos true y ponemos el flag a false
        // si no lo intentamos nuevamente hasta que giremos
        m_Grados = grados;
        if (CanTurn(grados))
        {
            transform.Rotate(new Vector3(0, grados, 0), Space.World);           
            return false;
        }
        return true;
    }

    private bool CanTurn(float grados)
    {
        var oldDirection = m_direction;
        if (grados == 90)
        {
            m_direction++;
        }
        else if (grados == -90)
        {
            m_direction--;
        }
        else
        {
            m_direction++;
            m_direction++;
        }
        if (m_direction > 3)
        {
            m_direction = 0;
        }
        if (m_direction < 0)
        {
            m_direction = 3;
        }
        if (this.CanMove())
        {
            return true;
        }
        m_direction = oldDirection;
        return false;
    }

    private bool CanMove()
    {
        Ray ray1 = new Ray(transform.position, Vector3.forward);
        Ray ray2 = new Ray(transform.position + new Vector3(0.51f,0,0), Vector3.forward);
        Ray ray3 = new Ray(transform.position + new Vector3(-0.51f, 0, 0), Vector3.forward);
        switch (m_direction)
        {
            case 0:
                ray1 = new Ray(transform.position, Vector3.forward);
                ray2 = new Ray(transform.position + new Vector3(0.51f, 0, 0), Vector3.forward);
                ray3 = new Ray(transform.position + new Vector3(-0.51f, 0, 0), Vector3.forward);
                break;
            case 1:
                ray1 = new Ray(transform.position, Vector3.right);
                ray2 = new Ray(transform.position + new Vector3(0, 0, -0.51f), Vector3.right);
                ray3 = new Ray(transform.position + new Vector3(0, 0, 0.51f), Vector3.right);
                break;
            case 2:
                ray1 = new Ray(transform.position, Vector3.back);
                ray2 = new Ray(transform.position + new Vector3(0.51f, 0, 0), Vector3.back);
                ray3 = new Ray(transform.position + new Vector3(-0.51f, 0, 0), Vector3.back);
                break;
            case 3:
                ray1 = new Ray(transform.position, Vector3.left);
                ray2 = new Ray(transform.position + new Vector3(0, 0, 0.51f), Vector3.left);
                ray3 = new Ray(transform.position + new Vector3(0, 0, -0.51f), Vector3.left);
                break;
            default:
                break;
        }

        if (
            Physics.Raycast(ray1, out RaycastHit hit, m_stop_distance) ||
            Physics.Raycast(ray2, out RaycastHit hit2, m_stop_distance) ||
            Physics.Raycast(ray3, out RaycastHit hit3, m_stop_distance)
            )
        {
            return false;
        }
        return true;
    }
}
