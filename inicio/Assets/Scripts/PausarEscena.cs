using UnityEngine;

public class PausarEscena : MonoBehaviour
{
    private bool juegoPausado = false;
    public GameObject Menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Puedes cambiar la tecla a la que quieras para pausar el juego
        {
            juegoPausado = !juegoPausado;
            if (juegoPausado)
            {
                PausarJuego();
            }
            else
            {
                ContinuarJuego();
            }
        }
    }

    void PausarJuego()
    {
        Menu.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
        
    }

    void ContinuarJuego()
    {
        Menu.SetActive(false);
        Time.timeScale = 1; // Continúa el juego
    }
}
