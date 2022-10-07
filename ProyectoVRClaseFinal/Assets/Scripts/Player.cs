using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform raycaster;
    [SerializeField] int initDirection;
    [SerializeField] Camera camera;
    Enemy[] enemies;
    float m_stop_distance = 1.7f;
    float m_Speed;
    Direction m_direction;
    float m_Grados;
    bool try_Turn;
    float speedH = 2;
    float speedV = 2;
    float yaw;
    float pitch;

    private enum Direction
    { 
        Forward =0,
        Right =1,
        Back = 2,
        Left = 3,
    };
    void Start()
    {
        m_Speed = 4.0f; // Ajustar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        m_Grados = 0;
        try_Turn = false;
    }

    void Update()
    {
        CameraControl();

        if (this.CanMove())
        {
            MoveForward();
        }

        if (try_Turn)
        {
            try_Turn = Girar(m_Grados);
        }

        if (
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetButtonDown("Jump")
            )
        {
            try_Turn = Girar(180);           
        }

        if (
            Input.GetKeyDown(KeyCode.RightArrow)||
            Input.GetButtonDown("Fire2")
            )
        {
            try_Turn = Girar(90);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetButtonDown("Fire3")
            )
        {
            try_Turn = Girar(-90);
        }
    }

    void CameraControl()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        camera.transform.eulerAngles = new Vector3(pitch,0.0f,0.0f);
    }

    private void MoveForward() {
        // Movimiento Constante 2 modos
        switch (m_direction)
        {
            case Direction.Forward:
                transform.position += Vector3.forward * Time.deltaTime * m_Speed;
                break;
            case Direction.Right:
                transform.position += Vector3.right * Time.deltaTime * m_Speed;
                break;
            case Direction.Back:
                transform.position += Vector3.back * Time.deltaTime * m_Speed;
                break;
            case Direction.Left:
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
            camera.transform.rotation = transform.rotation;
            return false;
        }
        return true;
    }

    private bool CanTurn(float grados)
    {
        var oldDirection = m_direction;
        if (grados == 90)
        {
            if (m_direction == Direction.Left)
            {
                m_direction = Direction.Forward;
            }
            else
            {
                m_direction++;
            }
        }
        else if (grados == -90)
        {
            if (m_direction == Direction.Forward)
            {
                m_direction = Direction.Left;
            }
            else
            {
                m_direction--;
            }
        }
        else
        {
            if (m_direction == Direction.Left)
            {
                m_direction = Direction.Forward;
            }
            else
            {
                m_direction++;
            }
            if (m_direction == Direction.Left)
            {
                m_direction = Direction.Forward;
            }
            else
            {
                m_direction++;
            }
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
            case Direction.Forward:
                ray1 = new Ray(transform.position, Vector3.forward);
                ray2 = new Ray(transform.position + new Vector3(0.51f, 0, 0), Vector3.forward);
                ray3 = new Ray(transform.position + new Vector3(-0.51f, 0, 0), Vector3.forward);
                break;
            case Direction.Right:
                ray1 = new Ray(transform.position, Vector3.right);
                ray2 = new Ray(transform.position + new Vector3(0, 0, -0.51f), Vector3.right);
                ray3 = new Ray(transform.position + new Vector3(0, 0, 0.51f), Vector3.right);
                break;
            case Direction.Back:
                ray1 = new Ray(transform.position, Vector3.back);
                ray2 = new Ray(transform.position + new Vector3(0.51f, 0, 0), Vector3.back);
                ray3 = new Ray(transform.position + new Vector3(-0.51f, 0, 0), Vector3.back);
                break;
            case Direction.Left:
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


    public void SetReferences()
    {
        enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.SetPlayer(this.gameObject);
        }
    }
}
