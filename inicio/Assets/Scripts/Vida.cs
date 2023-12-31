using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			bool vidaRecuperada = GameManager.Instance.RecuperarVida();

			if (vidaRecuperada)
			{
				Destroy(this.gameObject);
			}
		}
	}
}