using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text textoCompleto; // Referencia al objeto de texto completo
    private string textoCompletoOriginal; // El texto completo original
    private Text textoParcial; // Referencia al objeto de texto parcial (que se va escribiendo)
    public float velocidadEscritura = 0.1f; // Velocidad de escritura (en segundos por car�cter)

    private bool fading = false; // Indica si el texto est� desvaneci�ndose actualmente
    public float fadeOutDuration = 1f; // Duraci�n de la disoluci�n del texto
    public AudioSource soundEffect; // Referencia al AudioSource para reproducir el sonido al pulsar la tecla X

    void Start()
    {
        // Obtener referencia al componente Text del objeto de texto parcial
        textoParcial = GetComponent<Text>();

        // Almacenar el texto completo original
        textoCompletoOriginal = textoCompleto.text;

        // Iniciar la corutina para escribir el texto
        StartCoroutine(EscribirTexto());
    }

    void Update()
    {
        // Si se presiona la tecla X y no estamos desvaneci�ndonos actualmente, iniciar el fade out y cargar la siguiente escena
        if (Input.GetKeyDown(KeyCode.X) && !fading)
        {
            fading = true;
            soundEffect.Play(); // Reproducir el sonido
            StartCoroutine(FadeOutTextAndLoadNextScene());
        }
    }

    IEnumerator EscribirTexto()
    {
        textoParcial.text = ""; // Inicializar el texto parcial vac�o

        // Iterar a trav�s de cada car�cter del texto completo
        for (int i = 0; i < textoCompletoOriginal.Length; i++)
        {
            // Agregar el car�cter actual al texto parcial
            textoParcial.text += textoCompletoOriginal[i];

            // Esperar un tiempo determinado antes de agregar el siguiente car�cter
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }

    private IEnumerator FadeOutTextAndLoadNextScene()
    {
        Color originalColor = textoParcial.color;
        Color fadeOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Color completamente transparente

        // Disoluci�n gradual del texto
        float timer = 0f;
        while (timer < fadeOutDuration)
        {
            textoParcial.color = Color.Lerp(originalColor, fadeOutColor, timer / fadeOutDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Mantener el texto desvanecido
        textoParcial.color = fadeOutColor;

        // Cambiar de escena al finalizar el fade out
        SceneManager.LoadScene("BonesTardes");
    }
}
