using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{ // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] Transform enemySpawn;
    NavMeshAgent navMeshAgent;
    int chaseMode;

    // Variable booleana para saber si el enemigo ha sido Provocado
    public bool isScared = false;
     bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        chaseMode = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            BackToHome();
        }
        else
        {
            if (isScared)
            {
                EscapeFromTarget();
            }
            else
            {
                EngageTarget();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            if (isScared)
            {
                isDead = true;
                chaseMode = Random.Range(0, 4);
                //add points
            }
            else
            {
                //Perder una vida
                //reset player
                //reset enemies
            }
        }
    }

    private void EngageTarget()
    {
        switch (chaseMode)
        {
            case 1:
                navMeshAgent.SetDestination(target.position + new Vector3(1,0,1));
                break;
            case 2:
                navMeshAgent.SetDestination(target.position + new Vector3(2, 0, -2));
                break;
            case 3:
                navMeshAgent.SetDestination(target.position + new Vector3(-1, 0, 2));
                break;           
            default:
                navMeshAgent.SetDestination(target.position);
                break;
        }
    }

    // Función para perseguir al jugador
    private void EscapeFromTarget()
    {
        
    }
    
    // Función para perseguir al jugador
    private void BackToHome()
    {
        if (enemySpawn.position == gameObject.transform.position)
        {
            isDead = false;
        }
        navMeshAgent.SetDestination(enemySpawn.position);
    }

    // Función para perseguir al jugador
    private void SetScared(bool scared)
    {
        this.isScared = scared;
    }
}
