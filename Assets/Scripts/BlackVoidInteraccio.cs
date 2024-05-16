using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackVoidInteraccio : MonoBehaviour
{
    public BocadilloUI bocadilloUI;
    public BocadilloMissioUI bocadilloMissioUI; // Variable para almacenar la referencia a BocadilloMissioUI
    public AudioSource interactionSound;
    private bool jugadorDentro = false;
    private int contador = 1;
    string texteCanya = "Has obtingut 'Canya de Fnatic'.";

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
            jugadorDentro = false;
            bocadilloMissioUI.gameObject.SetActive(false);
            bocadilloMissioUI.LimpiarTexto(texteCanya);
        }
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador == 1 && TextManager.instance.comptadorBlackVoid == 10)
        {
            // Activar el GameObject del bocadillo y mostrar el texto
            if (bocadilloMissioUI != null)
            {
                Debug.Log("Estem dins i hem pitxat");
                interactionSound.Play();
                bocadilloMissioUI.ActivarYMostrarTexto(texteCanya);
                contador++; // Incrementar el contador después de mostrar el texto
                
            }
            else
            {
                Debug.LogWarning("BocadilloMissioUI no asignado en el editor de Unity.");
            }
        }
    }
}
