using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public HUD hud;

    private void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<ObjetoRecogible>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<ObjetoRecogible>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;

                // Desactiva el collider del objeto recogido si existe
                Collider myCollider = PickedObject.GetComponent<Collider>();
                if (myCollider != null)
                {
                    myCollider.enabled = false;
                }
                hud.ActualizarTextoObjetoAgarrable(ObjectToPickUp.name);
            }
        }
        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<ObjetoRecogible>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;

                // Reactiva el collider del objeto recogido si existe
                Collider myCollider = PickedObject.GetComponent<Collider>();
                if (myCollider != null)
                {
                    myCollider.enabled = true;
                    hud.ActualizarTextoObjetoAgarrable("");
                }

                PickedObject = null;
                
            }
        }
    }
}
