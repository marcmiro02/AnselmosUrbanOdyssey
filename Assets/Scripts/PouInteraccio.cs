using UnityEngine;

public class PouInteraccio : MonoBehaviour
{
    public BocadilloMissioUI bocadilloMissioUI; // Variable para almacenar la referencia a BocadilloMissioUI
    public AudioSource interactionSound;
    private bool jugadorDentro = false;
    private int contador = 1;
    string textePou = "Has obtingut 'Aigua Pipoliana' del pou.";

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
            bocadilloMissioUI.LimpiarTexto(textePou);
        }
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador == 1 && TextManager.instance.comptadorQuiosquero == 1)
        {
            // Activar el GameObject del bocadillo y mostrar el texto
            if (bocadilloMissioUI != null)
            {
                Debug.Log("Estem dins i hem pitxat");
                TextManager.instance.aigua = true;
                TextManager.instance.comptadorQuiosquero = 2;
                interactionSound.Play();
                bocadilloMissioUI.ActivarYMostrarTexto(textePou);
                contador++; // Incrementar el contador después de mostrar el texto
            }
            else
            {
                Debug.LogWarning("BocadilloMissioUI no asignado en el editor de Unity.");
            }
        }
    }
}
