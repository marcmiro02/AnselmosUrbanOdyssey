using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinaInteraccio : MonoBehaviour
{
    public BocadilloMissioUI bocadilloMissioUI; // Variable para almacenar la referencia a BocadilloMissioUI
    public static PiscinaInteraccio instance;
    public AudioSource interactionSound;
    public AudioSource interaccioDolenta;
    private bool jugadorDentro = false;
    private int contador = 1;
    string textePiscina;

    private void Start()
    {
        if(instance != null)
        {
            instance = this;
        }
    }
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
            bocadilloMissioUI.LimpiarTexto(textePiscina);
        }
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.X) && contador <= 10 && TextManager.instance.comptadorBlackVoid >= 10)
        {
            // Activar el GameObject del bocadillo y mostrar el texto
            if (bocadilloMissioUI != null)
            {
                MissatgePescar();

                Debug.Log("Estem dins i hem pitxat");
                if(contador == 3 || contador == 6 || contador == 10)
                {
                    interactionSound.Play();
                }
                else
                {
                    interaccioDolenta.Play();
                }
                    
                bocadilloMissioUI.ActivarYMostrarTexto(textePiscina);
                contador++; // Incrementar el contador después de mostrar el texto
            }
            else
            {
                Debug.LogWarning("BocadilloMissioUI no asignado en el editor de Unity.");
            }
        }
    }

    private void MissatgePescar()
    {
        if (contador == 1)
        {
            textePiscina = "Primer intent: Has pescat 'Sabates de cMaxc'.";
        }
        else if (contador == 2)
        {
            textePiscina = "Segon intent: Has pescat 'Pop mascota de DAM'.";
        }
        else if (contador == 3)
        {
            textePiscina = "Tercer intent: Has pescat 'Gorra de Martini: Mercedes'.";
        }
        else if (contador == 4)
        {
            textePiscina = "Quart intent: Has pescat 'Màquina arcade de DAM'.";
        }
        else if (contador == 5)
        {
            textePiscina = "Cinquè intent: Has pescat 'Encriptar dades per parar un incendi'.";
        }
        else if (contador == 6)
        {
            textePiscina = "Sisè intent: Has pescat 'Gorra de Martini: Ferrari'.";
        }
        else if (contador == 7)
        {
            textePiscina = "Setè intent: Has pescat 'Teclat de la Neneta'.";
        }
        else if (contador == 8)
        {
            textePiscina = "Vuitè intent: Has pescat 'Robertone'.";
        }
        else if (contador == 9)
        {
            textePiscina = "Novè intent: Has pescat 'ChatGPT'.";
        }
        else if (contador == 10)
        {
            textePiscina = "Desè intent: Has pescat 'Gorra de Martini: Aston Martin'.";
            TextManager.instance.comptadorBlackVoid = 11;
        }
    }
}
