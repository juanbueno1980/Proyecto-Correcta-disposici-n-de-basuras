using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform objetivo; // El objeto que quieres seguir
    public float velocidad = 5.0f; // Velocidad de seguimiento
    public Vector3 offset = new Vector3(0, 2, -10); // Offset de la c�mara con respecto al jugador

    void Update()
    {
        if (objetivo != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 posicionDeseada = objetivo.position + offset;

            // Interpola suavemente la posici�n de la c�mara
            Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, velocidad * Time.deltaTime);

            // Asigna la nueva posici�n a la c�mara
            transform.position = posicionSuave;
        }
    }
}
