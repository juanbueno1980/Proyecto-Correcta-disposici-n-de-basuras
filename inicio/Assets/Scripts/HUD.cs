using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
	private string nombreObjetoAgrar;

	public TextMeshProUGUI puntos;
	public GameObject[] vidas;
	public GameManager gameManager;
	public TextMeshProUGUI objetoAgarrableText;
	void Update()
	{
		puntos.text = GameManager.Instance.PuntosTotales.ToString();
	}

	public void ActualizarPuntos(int puntosTotales)
	{
		puntos.text = puntosTotales.ToString();
		Debug.Log(puntos);
	}
	public void ActualizarTextoObjetoAgarrable(string nombreObjeto)
	{
		objetoAgarrableText.text = nombreObjeto;
	}
	public void DesactivarVida(int indice)
	{
		vidas[indice].SetActive(false);
	}

	public void ActivarVida(int indice)
	{
		vidas[indice].SetActive(true);
	}
}