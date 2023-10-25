using UnityEngine;
using System.Linq;

public class PassthroughObjects : MonoBehaviour
{
    public string passthroughTag = "Passthrough"; // Etiqueta que pueden atravesar los objetos.

    void Start()
    {
        // Obtener todos los colliders en la escena con la etiqueta especificada.
        Collider[] passthroughColliders = GameObject.FindGameObjectsWithTag(passthroughTag)
            .Select(go => go.GetComponent<Collider>())
            .Where(collider => collider != null)
            .ToArray();

        // Ignorar colisiones entre este objeto y los colliders con la etiqueta especificada.
        foreach (var collider in passthroughColliders)
        {
            Physics.IgnoreCollision(collider, GetComponent<Collider>(), true);
        }
    }
}
