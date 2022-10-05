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
        // Ajustar cuando se cree nivel completo 
        if (other.CompareTag("TP1"))
        {
            gameObject.transform.position = new Vector3(tp2.transform.position.x, 4.5f, tp2.transform.position.z);
        }
        else if (other.CompareTag("TP2"))
        {
            gameObject.transform.position = new Vector3(tp1.transform.position.x, 4.5f, tp1.transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
