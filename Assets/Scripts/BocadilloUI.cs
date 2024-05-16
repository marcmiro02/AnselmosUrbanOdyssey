using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BocadilloUI : MonoBehaviour
{
    public static BocadilloUI instance;
    public Text nombreText;
    public Text textoText;

    // Diccionario para mapear tags a colores
    private Dictionary<string, Color> coloresPorTag = new Dictionary<string, Color>()
    {
        {"Quiosquero", Color.blue},
        {"CapitaTrinxat", Color.red},
        {"Professor", Color.magenta},
        {"BlackVoid", Color.black},
        {"Taxista", Color.yellow},
        {"Tim", Color.black},
        {"Ciclista", Color.magenta},
        {"Barquero", Color.green}
        // Agrega m�s tags y colores seg�n sea necesario
    };

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void MostrarTexto(string nombre, string texto, string tag)
    {
        // Configurar el texto del nombre del personaje
        nombreText.text = nombre;

        // Configurar el color del texto del nombre del personaje basado en el tag
        if (coloresPorTag.ContainsKey(tag))
        {
            nombreText.color = coloresPorTag[tag];
        }
        else
        {
            // Si el tag no est� en el diccionario, usar color blanco por defecto
            nombreText.color = Color.white;
        }

        // Configurar el texto del di�logo
        textoText.text = texto;
    }

    public void LimpiarTexto()
    {
        // Limpiar los textos del bocadillo
        nombreText.text = "";
        textoText.text = "";
    }
}