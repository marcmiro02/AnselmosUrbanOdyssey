using UnityEngine;
using UnityEngine.UI;

public class PersonajeInteractuable : MonoBehaviour
{
    public static PersonajeInteractuable instance;
    public string nombrePersonaje;
    public GameObject bocadilloUI;
    public AudioSource interactSound;
    private bool enAreaInteraccion = false;
    private bool mostrandoTexto = false; // Variable para controlar si se está mostrando texto
    public bool puedeInteractuar = true; // Variable para controlar si se puede interactuar
    public bool preguntaFormulada = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        bocadilloUI.SetActive(false);

    }

    void Update()
    {
        // Verificar si se está mostrando el texto y si ya no se está en el área de interacción
 
        if (puedeInteractuar)
        {
            // Verificar si se está mostrando el texto y si ya no se está en el área de interacción
            if (mostrandoTexto && !enAreaInteraccion)
            {
                // Detener el texto y ocultar el bocadillo
                mostrandoTexto = false;
                DetenerEscrituraTexto();
            }
            // Verificar si se puede interactuar (es decir, si no se está mostrando el bocadillo de preguntas)
            if (enAreaInteraccion && Input.GetKeyDown(KeyCode.X))
            {
                if (interactSound != null)
                {
                    interactSound.Play();
                }

                bocadilloUI.SetActive(true);
                mostrandoTexto = true; // Marcar que se está mostrando texto
                MostrarTexto(nombrePersonaje);
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enAreaInteraccion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enAreaInteraccion = false;
            if (!mostrandoTexto) // Si no se está mostrando texto, limpiar el texto del bocadillo
            {
                DetenerEscrituraTexto();
            }
        }
    }

    void MostrarTexto(string nombre)
    {
        var bocadilloUIComponent = bocadilloUI.GetComponent<BocadilloUI>();
        string texto = "";

        if (gameObject.tag == "Quiosquero")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoQuiosquero(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Quiosquero");
        }
        else if (gameObject.tag == "CapitaTrinxat")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoTrinxat(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "CapitaTrinxat");
        }
        else if (gameObject.tag == "Professor")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoProfessor(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Professor");
        }
        else if (gameObject.tag == "BlackVoid")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoBlackVoid(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "BlackVoid");
        }
        else if (gameObject.tag == "Taxista")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoTaxista(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Taxista");
        }
        else if (gameObject.tag == "Tim")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoTim(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Tim");
        }
        else if (gameObject.tag == "Ciclista")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoCiclista(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Ciclista");
        }
        else if (gameObject.tag == "Barquero")
        {
            texto = TextManager.instance.ObtenerSiguienteTextoBarquero(); // Obtener texto del Quiosquero desde el TextManager
            bocadilloUIComponent.MostrarTexto(nombre, texto, "Barquero");
        }
        //Si nhi ha mes, ficarne mes.

        // Activar el objeto del texto con el typewriter
        bocadilloUIComponent.textoText.gameObject.SetActive(true);

        // Obtener el componente TypeWriterBocadillo del objeto Text
        var textoComponent = bocadilloUIComponent.textoText.GetComponent<TypeWriterBocadillo>();

        // Iniciar el efecto de escritura
        textoComponent.EscribirTexto(bocadilloUIComponent.textoText, texto);
    }

    void DetenerEscrituraTexto()
    {
        var bocadilloUIComponent = bocadilloUI.GetComponent<BocadilloUI>();
        bocadilloUI.SetActive(false); // Desactivar el GameObject del bocadillo
        bocadilloUIComponent.textoText.gameObject.SetActive(false); // Ocultar el texto
        bocadilloUIComponent.LimpiarTexto(); // Limpiar el texto del bocadillo

        // Permitir la interacción nuevamente cuando se oculta el bocadillo
        puedeInteractuar = true;
    }

    public void EstablecerPreguntaFormulada()
    {
        preguntaFormulada = true;
    }

}
