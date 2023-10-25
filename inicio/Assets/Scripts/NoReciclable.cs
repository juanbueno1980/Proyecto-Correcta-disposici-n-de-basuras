
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoReciclable : MonoBehaviour
{

    public int valor = 1;
    public int menorvalor = -1;
    public GameManager gameManager;
    private AudioSource audioSource;
    private AudioSource audioSource2;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ContenedorNoReciclable"))
        {
            // Sumar puntos cuando colisiona con "ContenedorNoReciclable"
            gameManager.SumarPuntos(valor);
            Destroy(gameObject);
            audioSource.Play();
        }
        else if (collision.CompareTag("ContenedorReciclable") || collision.CompareTag("ContenedorOrganico"))
        {
            // Restar puntos cuando colisiona con "ContenedorReciclable" o "ContenedorOrganico"
            gameManager.SumarPuntos(menorvalor);
            Destroy(gameObject);
            audioSource2.Play();
        }

        // Destruir el objeto actual en cualquier caso

    }
}