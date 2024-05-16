using UnityEngine;

public class PaperetInteraccio : MonoBehaviour
{
    public BocadilloMissioUI bocadilloMissioUI; // Variable para almacenar la referencia a BocadilloMissioUI
    public AudioSource interactionSound;
    private bool jugadorDentro = false;
    private int contador = 1;
    string textePaperet = "Has obtingut '*8**'.";

    private bool destruccio = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorDentro = true;
            Debug.Log("Estem dins");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorDentro = false;
            bocadilloMissioUI.gameObject.SetActive(false);
            bocadilloMissioUI.LimpiarTexto(textePaperet);
            if (destruccio)
            {
                Destroy(gameObject);
            }

        }
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador == 1)
        {
            // Activar el GameObject del bocadillo y mostrar el texto
            if (bocadilloMissioUI != null)
            {
                Debug.Log("Estem dins i hem pitxat");
                interactionSound.Play();
                bocadilloMissioUI.ActivarYMostrarTexto(textePaperet);
                contador++; // Incrementar el contador después de mostrar el texto
                destruccio = true;
            }
            else
            {
                Debug.LogWarning("BocadilloMissioUI no asignado en el editor de Unity.");
            }
        }
    }
}
