using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjetoRecogible : MonoBehaviour
{
    public bool isPickable = true;
    public string nombreObjeto; // Agrega una variable para el nombre del objeto

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            Personaje personaje = other.GetComponentInParent<Personaje>();
            personaje.ObjectToPickUp = this.gameObject;

            // Muestra el nombre del objeto en el Canvas
            TextoObjetoRecogible textoCanvas = FindObjectOfType<TextoObjetoRecogible>();
            textoCanvas.MostrarNombreObjeto("*" + nombreObjeto); // Modificación aquí
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<Personaje>().ObjectToPickUp = null;

            // Oculta el nombre del objeto en el Canvas
            TextoObjetoRecogible textoCanvas = FindObjectOfType<TextoObjetoRecogible>();
            textoCanvas.OcultarNombreObjeto();
        }
    }
}
