using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{ // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] Transform enemySpawn;
    [SerializeField] MenuManager menuManager;
    NavMeshAgent navMeshAgent;
    int chaseMode;
    public bool isActive = false;

    // Variable booleana para saber si el enemigo ha sido Provocado
    public bool isScared = false;
     bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        chaseMode = Random.Range(0,4);
        FindObjectOfType<Player>().SetReferences();
        menuManager = FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuManager.IsPaused() && isActive)
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
        else {
            navMeshAgent.SetDestination(transform.position);
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
        Vector3 destiny = target.position;
        switch (chaseMode)
        {
            case 1:
                destiny += new Vector3(Random.Range(0,1), 0, Random.Range(0, 2));
                break;
            case 2:
                destiny += new Vector3(Random.Range(0,2), 0, Random.Range(1, 3));
                break;
            case 3:
                destiny += new Vector3(Random.Range(0,1), 0, Random.Range(1, 3));
                break;           
            default:
                break;
        }
        navMeshAgent.SetDestination(destiny);
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
    public void SetPlayer(GameObject player)
    {
        target = player.transform;
    }
}
