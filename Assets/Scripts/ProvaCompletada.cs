using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaCompletada : MonoBehaviour
{

    public static ProvaCompletada instance;
    public BocadilloMissioUI bocadilloMissioUI;
    public AudioSource interactionSound;
    private bool jugadorDentro = false;
    public int comptadorProves = 0;

    string texte;

    private void Start()
    {
        if(instance == null)
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
            bocadilloMissioUI.LimpiarTexto(texte);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorDentro)
        {

            if (bocadilloMissioUI != null)
            {
                if (comptadorProves == 1)
                {
                    texte = "'Laberint de la UDL' completat.";
                    comptadorProves = 0;
                    interactionSound.Play();
                    bocadilloMissioUI.ActivarYMostrarTexto(texte);
                }
                else if (comptadorProves == 2)
                {
                    texte = "'Joc de preguntes' completat.";
                    comptadorProves = 0;
                    interactionSound.Play();
                    bocadilloMissioUI.ActivarYMostrarTexto(texte);
                }
                else if (comptadorProves == 3)
                {
                    texte = "'Pescació' completada.";
                    comptadorProves = 0;
                    interactionSound.Play();
                    bocadilloMissioUI.ActivarYMostrarTexto(texte);
                }
            }
        }
    }
}
