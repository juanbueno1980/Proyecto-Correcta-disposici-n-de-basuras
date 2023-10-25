using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject Empezar;
    void Start()
    {
        Empezar.SetActive(true);
    }    public void EmpezarOn()
    {
        Empezar.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
