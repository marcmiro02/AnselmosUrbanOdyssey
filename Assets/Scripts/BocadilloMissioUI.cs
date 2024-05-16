using UnityEngine;
using UnityEngine.UI;

public class BocadilloMissioUI : MonoBehaviour
{
    public Text textoText;

    void Start()
    {
        gameObject.SetActive(false); // Desactivar la imagen al inicio
    }

    // Método para activar el bocadillo y establecer el texto
    public void ActivarYMostrarTexto(string texto)
    {
        textoText.text = texto; // Establecer el texto
        gameObject.SetActive(true); // Activar el GameObject del bocadillo
    }

    public void LimpiarTexto(string texto)
    {
        textoText.text = "";
    }

}
