using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportation : MonoBehaviour
{
     TP1 tp1;
     TP2 tp2;
    // Start is called before the first frame update
    void Start()
    {
       tp1 = FindObjectOfType<TP1>();
       tp2 = FindObjectOfType<TP2>();        
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
