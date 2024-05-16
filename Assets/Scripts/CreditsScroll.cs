using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas

public class CreditsScroll : MonoBehaviour
{
    public Transform creditsText; // Asigna el objeto de texto de los cr�ditos desde el editor
    public float scrollSpeed = 1.0f; // Velocidad de desplazamiento de los cr�ditos
    public float endPositionY = 1134.0f; // Ajusta esto seg�n el punto en que el texto de los cr�ditos deba considerarse terminado

    void Update()
    {
        // Desplazar el objeto de texto hacia arriba
        creditsText.position += Vector3.up * scrollSpeed * Time.deltaTime;

        // Comprobar si los cr�ditos han terminado
        if (creditsText.position.y >= endPositionY)
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene("Menu");
        }
    }
}
