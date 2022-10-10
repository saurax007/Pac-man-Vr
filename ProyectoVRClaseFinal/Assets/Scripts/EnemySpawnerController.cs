using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject[] ghosts;

    [SerializeField] GameObject playerSpawner;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnGhost", 1f);
        Invoke("SpawnPlayer", 0.25f);
    }

    void SpawnGhost()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(ghosts[i], spawners[i].transform.position, Quaternion.identity);
        }
    }

    void SpawnPlayer()
    {
        Instantiate(player, playerSpawner.transform.position, Quaternion.identity);
    }

    public void ResetPlayer()
    {
        player.transform.position = playerSpawner.transform.position;
        player.transform.rotation = playerSpawner.transform.rotation;
    }
}
