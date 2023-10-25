using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour
{
    public GameObject options;
    public Slider sliderPuntos;

    public GameObject Menu;
    public string clavePuntosGanar = "PuntosGanar";
    public TextMeshProUGUI textoPuntos; // Asegúrate de asignar el TextMeshPro en el Inspector
    public TextMeshProUGUI textMesh;
    private void Start()
    {
        options.SetActive(false);
        if (PlayerPrefs.HasKey(clavePuntosGanar))
        {
            int puntosGuardados = PlayerPrefs.GetInt(clavePuntosGanar);
            sliderPuntos.value = puntosGuardados;
            textoPuntos.text = puntosGuardados.ToString();

        }

        // Agregamos un listener al slider para que se actualice automáticamente.
        sliderPuntos.onValueChanged.AddListener(ActualizarValor);
    }

    public void ActualizarValor(float nuevoValor)
    {
        Debug.Log("Nuevo valor: " + nuevoValor);
        textoPuntos.text = nuevoValor.ToString();
        textMesh.text = nuevoValor.ToString();
    }

    public void GuardarValor()
    {
        // Obtiene el valor actual del slider y lo guarda en PlayerPrefs.
        int nuevoValor = Mathf.RoundToInt(sliderPuntos.value);
        PlayerPrefs.SetInt(clavePuntosGanar, nuevoValor);

    }

    // Resto de tus métodos...

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void iralmenu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Menul()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OptionsOn()
    {
        options.SetActive(true);
    }

    public void OptionsOff()
    {
        options.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}