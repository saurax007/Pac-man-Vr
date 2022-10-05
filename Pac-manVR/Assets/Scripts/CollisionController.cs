using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] float value = 100;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            // Restart game

        }
        if (other.CompareTag("Bola"))
        {
            // Aumentar puntución
        }

        Destroy(other.gameObject);
    }
}
