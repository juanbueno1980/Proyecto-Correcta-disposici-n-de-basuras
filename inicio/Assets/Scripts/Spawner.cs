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
    public float minSpawnTime = 1.0f;   // Tiempo m�nimo entre apariciones
    public float maxSpawnTime = 3.0f;   // Tiempo m�ximo entre apariciones

    private float spawnTimer;

    public Transform jugador; // Referencia al jugador que seguir� el spawner
    public float velocidadSeguimiento = 5f; // Velocidad a la que seguir� al jugador en el eje X
    public float distanciaDeseadaX = 5f; // Distancia deseada en el eje X entre el spawner y el jugador
    public float distanciaMinimaZ = 5f; // Distancia m�nima en el eje Z para activar el spawner
    public bool seguirEnSentidoNegativo = false; // Indica si el spawner debe seguir en el sentido negativo (izquierda) o positivo (derecha)

    void Start()
    {
        // Inicializa el temporizador de aparici�n con un valor aleatorio
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Calcula la direcci�n hacia el jugador
        float direccion = seguirEnSentidoNegativo ? -1f : 1f;

        // Calcula la posici�n X a la que debe moverse el spawner
        float nuevaPosX = jugador.position.x - (direccion * distanciaDeseadaX);

        // Aplica la nueva posici�n X con suavidad
        Vector3 nuevaPosicion = new Vector3(nuevaPosX, transform.position.y, transform.position.z);

        // Calcula la distancia en el eje Z entre el spawner y el jugador
        float distanciaZ = Mathf.Abs(jugador.position.z - transform.position.z);

        // Verifica la distancia en el eje Z antes de activar el spawner
        if (distanciaZ <= distanciaMinimaZ)
        {
            // Actualiza el temporizador de aparici�n
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

        // Genera el objeto en la posici�n del Spawner (este objeto) con la rotaci�n deseada
        GameObject spawnedObject = Instantiate(selectedObject.objectPrefab, transform.position, Quaternion.Euler(selectedObject.initialRotation));
    }
}
