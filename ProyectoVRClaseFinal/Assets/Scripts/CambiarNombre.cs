using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarNombre : MonoBehaviour
{
    [SerializeField] Text miTexto;

    private void Start()
    {
        miTexto.text = "Debug";
    }
    public void Entrando()
    {

        miTexto.text = "INFO";
    }
    public void Presionando()
    {
        miTexto.text = "SOY UN OBJECTO VACIO";
    }
    public void Saliendo()
    {
        miTexto.text = "INFO";
    }
}
