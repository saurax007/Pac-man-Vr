using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportation : MonoBehaviour
{
    [SerializeField] GameObject tp1;
    [SerializeField] GameObject tp2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TP1"))
        {
            gameObject.transform.position = tp2.transform.position;
        }
        else if (other.CompareTag("TP2"))
        {
            gameObject.transform.position = tp1.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
