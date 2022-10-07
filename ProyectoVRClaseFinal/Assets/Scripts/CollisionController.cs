using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    float scaredTime = 0;

    private void Update()
    {
        scaredTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            // Restart game
            Invoke("ResetPlayer", 1f);
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
            scaredTime = 0;
            Invoke("ResetScare",0f);
        }        
    }


    private void ResetScare()
    {
        if (scaredTime >= 15)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                enemy.isScared = false;
            }
        }
        else
        {
            Invoke("ResetScare", 0.5f);
        } 
    }


    private void ResetPlayer()
    {
        FindObjectOfType<EnemySpawnerController>().ResetPlayer();
    }
}
