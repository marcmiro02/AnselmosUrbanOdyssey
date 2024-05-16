// ColorNombrePersonaje.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorNombrePersonaje : MonoBehaviour
{
    private Text nombreText;

    private Dictionary<string, Color> coloresPorTag = new Dictionary<string, Color>()
    {
        {"Quiosquero", Color.blue},
        // Agrega m�s tags y colores seg�n sea necesario
    };

    void Start()
    {
        nombreText = GetComponent<Text>();
    }

    public void AplicarColorPorTag(string tag)
    {
        if (coloresPorTag.ContainsKey(tag))
        {
            nombreText.color = coloresPorTag[tag];
        }
        else
        {
            nombreText.color = Color.white;
        }
    }
}
