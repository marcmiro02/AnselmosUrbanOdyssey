using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeTextOnKeyPress : MonoBehaviour
{
    public Text textoZona; // Referencia al objeto de texto en pantalla para mostrar el nombre de la zona
    public float fadeInDuration = 1f; // Duración de la aparición del texto
    public float fadeOutDuration = 1f; // Duración de la disolución del texto
    public AudioSource soundEffect; // Referencia al AudioSource para reproducir el sonido

    private bool fading = false; // Indica si el texto está desvaneciéndose actualmente

    void Start()
    {
        // Comienza el fade in al inicio
        StartCoroutine(FadeInText());
    }

    void Update()
    {
        // Si se presiona la tecla X y no estamos desvaneciéndonos actualmente, iniciar el fade out y cambiar de escena
        if (Input.GetKeyDown(KeyCode.X) && !fading)
        {
            fading = true;
            soundEffect.Play(); // Reproducir el sonido
            StartCoroutine(FadeOutTextAndLoadNextScene());
        }
    }

    private System.Collections.IEnumerator FadeInText()
    {
        Color originalColor = textoZona.color;
        Color fadeOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Color completamente transparente

        // Inicia el texto completamente transparente
        textoZona.color = fadeOutColor;

        // Aparición gradual del texto
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float normalizedTime = elapsedTime / fadeInDuration;
            textoZona.color = Color.Lerp(fadeOutColor, originalColor, normalizedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Mantener el texto visible al finalizar el fade in
        textoZona.color = originalColor;
    }

    private System.Collections.IEnumerator FadeOutTextAndLoadNextScene()
    {
        Color originalColor = textoZona.color;
        Color fadeOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Color completamente transparente

        // Disolución gradual del texto
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float normalizedTime = elapsedTime / fadeOutDuration;
            textoZona.color = Color.Lerp(originalColor, fadeOutColor, normalizedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Mantener el texto desvanecido
        textoZona.color = fadeOutColor;

        // Cambiar de escena al finalizar el fade out
        SceneManager.LoadScene("Introduccio");
    }

}
