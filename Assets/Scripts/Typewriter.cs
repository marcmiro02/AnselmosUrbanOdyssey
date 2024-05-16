using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeWriterBocadillo : MonoBehaviour
{
    public float velocidadEscritura = 0.1f; // Velocidad de escritura (en segundos por car�cter)

    private Coroutine coroutine; // Referencia al coroutine de escritura

    public void EscribirTexto(Text texto, string textoCompleto)
    {
        // Si hay una escritura en curso, la detenemos antes de iniciar una nueva
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(Escribir(texto, textoCompleto));
    }

    IEnumerator Escribir(Text texto, string textoCompleto)
    {
        texto.text = ""; // Inicializar el texto vac�o

        // Iterar a trav�s de cada car�cter del texto completo
        for (int i = 0; i < textoCompleto.Length; i++)
        {
            // Agregar el car�cter actual al texto parcial
            texto.text += textoCompleto[i];

            // Esperar un tiempo determinado antes de agregar el siguiente car�cter
            yield return new WaitForSeconds(velocidadEscritura);
        }

        // Al completar la escritura, eliminamos la referencia al coroutine
        coroutine = null;
    }
}