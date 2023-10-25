using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Ganaste;
    public GameObject jugador;
    public GameObject final;
    public GameObject Menu;
    public static GameManager Instance { get; private set; }
    public Slider sliderPuntos;
    public HUD hud;

    public int PuntosTotales { get; private set; }
    private int Puedeganar = 10; // Valor predeterminado

    private int vidas = 3;

    void Start()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        // Agregamos un listener al slider para que se actualice automáticamente.
        sliderPuntos.onValueChanged.AddListener(VerificarGanar);
        sliderPuntos.value = Puedeganar; // Asegúrate de que el valor inicial se configure en el slider.
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void VerificarGanar(float nuevoValor)
    {
        Puedeganar = Mathf.RoundToInt(nuevoValor);
    }

    public void SumarPuntos(int puntosASumar)
    {
        VerificarGanar(sliderPuntos.value);
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
        

        if (PuntosTotales >= Puedeganar)
        {
            Time.timeScale = 0;
            Ganaste.SetActive(true);
        }
    }

    public void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            Time.timeScale = 0;
            final.SetActive(true);
        }

        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }

        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
