using UnityEngine;
using TMPro;

public class TextoObjetoRecogible : MonoBehaviour
{
    public TextMeshProUGUI textoObjetoRecogible;

    private void Start()
    {
        // Asegúrate de que el texto inicialmente esté vacío
        textoObjetoRecogible.text = "";
    }

    public void MostrarNombreObjeto(string nombreObjeto)
    {
        textoObjetoRecogible.text = "Objeto Recogible: " + nombreObjeto;
    }

    public void OcultarNombreObjeto()
    {
        textoObjetoRecogible.text = "";
    }
}
