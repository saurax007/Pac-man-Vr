using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            // Restart game

        }
        if (other.CompareTag("Bola"))
        {
            // Aumentar puntución
            Destroy(other.gameObject);
        }
    }
}
