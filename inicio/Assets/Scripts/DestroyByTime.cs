using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 5.0f; // Tiempo en segundos antes de destruir el objeto

    void Start()
    {
        // Invoca el método DestroyObject después de 'destroyTime' segundos
        Invoke("DestroyObject", destroyTime);
    }

    void DestroyObject()
    {
        // Destruye el objeto actual
        Destroy(gameObject);
    }
}
