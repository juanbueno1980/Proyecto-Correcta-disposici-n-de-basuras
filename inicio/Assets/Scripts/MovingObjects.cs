using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    private AudioSource audioSource;
    public float minSpeed, maxSpeed;
    public float stopTime = 5.0f; // Tiempo de espera después de la colisión
    public bool moverEnSentidoNegativo = false; // Indica si el objeto debe moverse en sentido negativo (izquierda) o positivo (derecha)

    private Rigidbody rb;
    private Vector3 initialVelocity; // Guardar la velocidad inicial
    private bool isStopped = false; // Para controlar si el objeto está detenido

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        // Configura la dirección de movimiento inicial según la variable moverEnSentidoNegativo
        if (moverEnSentidoNegativo)
        {
            initialVelocity = new Vector3(-Random.Range(minSpeed, maxSpeed), 0, 0); // Sentido negativo
        }
        else
        {
            initialVelocity = new Vector3(Random.Range(minSpeed, maxSpeed), 0, 0); // Sentido positivo
        }

        rb.velocity = initialVelocity;
    }

    void FixedUpdate()
    {
        if (!isStopped)
        {
            rb.velocity = initialVelocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isStopped)
        {
            // Comprueba si la colisión es con otro objeto
            if (collision.gameObject.CompareTag("Player"))
            {
                isStopped = true;
                audioSource.Play();
                rb.velocity = Vector3.zero; // Detener el objeto
                StartCoroutine(ResumeAfterDelay());
            }
        }
    }

    IEnumerator ResumeAfterDelay()
    {
        yield return new WaitForSeconds(stopTime);
        isStopped = false;

        // Reanuda el movimiento en la misma dirección
        rb.velocity = initialVelocity;
    }
}
