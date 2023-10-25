using UnityEngine;
using TMPro;

public class TextoObjetoRecogible : MonoBehaviour
{
    public TextMeshProUGUI textoObjetoRecogible;

    private void Start()
    {
        // Aseg�rate de que el texto inicialmente est� vac�o
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
