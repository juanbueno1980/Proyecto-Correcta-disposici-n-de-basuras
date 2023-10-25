using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectToSpawn
{
    public GameObject objectPrefab;
    public Vector3 initialRotation;
}

public class Spawner : MonoBehaviour
{
    public ObjectToSpawn[] objectsToSpawn; // Array de objetos que pueden aparecer
    public float minSpawnTime = 1.0f;   // Tiempo mínimo entre apariciones
    public float maxSpawnTime = 3.0f;   // Tiempo máximo entre apariciones

    private float spawnTimer;

    public Transform jugador; // Referencia al jugador que seguirá el spawner
    public float velocidadSeguimiento = 5f; // Velocidad a la que seguirá al jugador en el eje X
    public float distanciaDeseadaX = 5f; // Distancia deseada en el eje X entre el spawner y el jugador
    public float distanciaMinimaZ = 5f; // Distancia mínima en el eje Z para activar el spawner
    public bool seguirEnSentidoNegativo = false; // Indica si el spawner debe seguir en el sentido negativo (izquierda) o positivo (derecha)

    void Start()
    {
        // Inicializa el temporizador de aparición con un valor aleatorio
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Calcula la dirección hacia el jugador
        float direccion = seguirEnSentidoNegativo ? -1f : 1f;

        // Calcula la posición X a la que debe moverse el spawner
        float nuevaPosX = jugador.position.x - (direccion * distanciaDeseadaX);

        // Aplica la nueva posición X con suavidad
        Vector3 nuevaPosicion = new Vector3(nuevaPosX, transform.position.y, transform.position.z);

        // Calcula la distancia en el eje Z entre el spawner y el jugador
        float distanciaZ = Mathf.Abs(jugador.position.z - transform.position.z);

        // Verifica la distancia en el eje Z antes de activar el spawner
        if (distanciaZ <= distanciaMinimaZ)
        {
            // Actualiza el temporizador de aparición
            spawnTimer -= Time.deltaTime;

            // Si el temporizador llega a cero o menos, genera un objeto y reinicia el temporizador
            if (spawnTimer <= 0)
            {
                SpawnObject();
                spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }

    }

    void SpawnObject()
    {
        // Elije un objeto aleatorio del array
        ObjectToSpawn selectedObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Genera el objeto en la posición del Spawner (este objeto) con la rotación deseada
        GameObject spawnedObject = Instantiate(selectedObject.objectPrefab, transform.position, Quaternion.Euler(selectedObject.initialRotation));
    }
}
