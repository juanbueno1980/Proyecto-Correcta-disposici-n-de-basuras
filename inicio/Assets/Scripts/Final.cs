using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject final;
    public GameObject Ganaste;
    public void Start()
    {
        final.SetActive(false);
        Ganaste.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ReintentarOn()
    {
        SceneManager.LoadScene("Game");
    }
 
    public void Salir()
    {
        Application.Quit();
    }
}
