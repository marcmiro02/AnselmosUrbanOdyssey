using UnityEngine;
using UnityEngine.SceneManagement;

public class TrinxatInteraccio : MonoBehaviour
{
    public BocadilloUI bocadilloUI;
    public BocadilloMissioUI bocadilloMissioUI; // Variable para almacenar la referencia a BocadilloMissioUI
    public AudioSource interactionSound;
    private bool jugadorDentro = false;
    private int contador = 1;
    string textePremi = "Has obtingut 'Component2'.";
    string texteFinal = "Has obtingut 'El Canyó de'n Discard'.";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (contador == 2)
            {
                jugadorDentro = false;
                bocadilloMissioUI.gameObject.SetActive(false);
                bocadilloMissioUI.LimpiarTexto(textePremi);
                contador++;
            }
            else if (contador == 4)
            {
                jugadorDentro = false;
                bocadilloMissioUI.gameObject.SetActive(false);
                bocadilloMissioUI.LimpiarTexto(texteFinal);
                contador++;
                SceneManager.LoadScene("VideoDiscard");
            }
        }
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador == 1 && TextManager.instance.comptadorTrinxat == 26)
        {
            // Activar el GameObject del bocadillo y mostrar el texto
            if (bocadilloMissioUI != null)
            {
                Debug.Log("Estem dins i hem pitxat");
                interactionSound.Play();
                bocadilloMissioUI.ActivarYMostrarTexto(textePremi);
                contador++; // Incrementar el contador después de mostrar el texto
                TextManager.instance.comptadorComponents++;
            }
            else
            {
                Debug.LogWarning("BocadilloMissioUI no asignado en el editor de Unity.");
            }
        }
        else if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador == 3 && TextManager.instance.comptadorTrinxat == 34)
        {
            if (bocadilloMissioUI != null)
            {
                interactionSound.Play();
                bocadilloMissioUI.ActivarYMostrarTexto(texteFinal);
                contador++;
            }
        }
    }
}
