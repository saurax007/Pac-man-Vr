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

        if (other.CompareTag("Fruta"))
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                enemy.isScared = true;
            }
            Invoke("ResetScare",15f);
        }
    }
    private void ResetScare()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.isScared = false;
        }
    }
}
