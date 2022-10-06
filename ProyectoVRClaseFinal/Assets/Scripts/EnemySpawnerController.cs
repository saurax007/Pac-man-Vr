using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject[] ghost;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnGhost", 1f);
    }

    void SpawnGhost()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(ghost[i], spawners[i].transform.position, Quaternion.identity);
        }
    }
}
