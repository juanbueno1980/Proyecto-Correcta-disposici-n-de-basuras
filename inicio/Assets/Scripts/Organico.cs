
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organico : MonoBehaviour
{

    public int valor = 1;
    public int menorvalor = -1;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ContenedorOrganico"))
        {
            // Sumar puntos cuando colisiona con "ContenedorNoReciclable"
            gameManager.SumarPuntos(valor);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ContenedorNoReciclable") || collision.CompareTag("ContenedorReciclable"))
        {
            // Restar puntos cuando colisiona con "ContenedorReciclable" o "ContenedorOrganico"
            gameManager.SumarPuntos(menorvalor);
            Destroy(gameObject);
        }

        // Destruir el objeto actual en cualquier caso

    }
}