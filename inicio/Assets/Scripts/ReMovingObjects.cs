using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReMovingObjects : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float stopTime = 5.0f; // Tiempo de espera después de la colisión

    private Rigidbody rb;
    private Vector3 initialVelocity; // Guardar la velocidad inicial
    private bool isStopped = false; // Para controlar si el objeto está detenido

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialVelocity = new Vector3(Random.Range(minSpeed, maxSpeed), 0, 0);
        rb.velocity = -initialVelocity;
    }

    void FixedUpdate()
    {
        if (!isStopped)
        {
            rb.velocity = -initialVelocity;
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
                rb.velocity = Vector3.zero; // Detener el objeto
                StartCoroutine(ResumeAfterDelay());
            }
        }
    }

    IEnumerator ResumeAfterDelay()
    {
        yield return new WaitForSeconds(stopTime);
        isStopped = false;
        rb.velocity = -initialVelocity; // Reanudar el movimiento
    }
}
