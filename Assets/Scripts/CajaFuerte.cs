using UnityEngine;
using UnityEngine.UI;

public class CajaFuerte : MonoBehaviour
{
    public Sprite spriteDesbloqueado; // Referencia al sprite que se mostrará cuando la caja fuerte esté desbloqueada

    public BocadilloMissioUI bocadilloMissioUI;
    private bool playerInRange = false;
    private bool inputEnabled = false;
    private string inputString = "";
    private int maxDigits = 4; // Número máximo de dígitos que el jugador puede introducir
    private string pinCorrecto = "3872"; // Pin correcto

    public BafaradaContrasenya bafaradaContrasenya; // Referencia al script BafaradaContrasenya
    public Text inputText; // Referencia al objeto Text asociado al inputPassword

    public AudioSource obrirCofre;
    public AudioSource pop;

    private bool contador = true;
    private bool activatione = true;

    private string texteComp3 = "Has obtingut 'Component3'.";

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.X) && contador && activatione)
        {
            inputEnabled = true;

            if (bafaradaContrasenya != null)
            {
                bafaradaContrasenya.ActivarElementos();
                pop.Play();
                activatione = false;    
            }
        }

        if (inputEnabled)
        {
            foreach (char c in Input.inputString)
            {
                // Permitir borrar con "Backspace"
                if (c == '\b')
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length - 1);
                        inputText.text = inputString;
                    }
                }
                else if (char.IsDigit(c) && inputString.Length < maxDigits)
                {
                    inputString += c;
                    inputText.text = inputString;

                    // Verificar si se ha introducido el pin correcto
                    if (inputString.Length == maxDigits && inputString == pinCorrecto)
                    {
                        // Desbloquear la caja fuerte
                        DesbloquearCajaFuerte();
                    }
                }
            }
        }

        // Limpiar campo de entrada al salir del rango
        if (!playerInRange)
        {
            inputEnabled = false;
            inputString = "";
            inputText.text = "";
            if (bafaradaContrasenya != null)
            {
                bafaradaContrasenya.DesactivarElementos();
                activatione = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            bocadilloMissioUI.gameObject.SetActive(false);
            bocadilloMissioUI.LimpiarTexto(texteComp3);
        }
    }

    private void DesbloquearCajaFuerte()
    {
        // Cambiar el sprite de la caja fuerte al sprite desbloqueado
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && spriteDesbloqueado != null)
        {
            spriteRenderer.sprite = spriteDesbloqueado;
        }
        obrirCofre.Play();
        bafaradaContrasenya.DesactivarElementos();
        bocadilloMissioUI.ActivarYMostrarTexto(texteComp3);
        contador = false;
        TextManager.instance.comptadorQuiosquero = 45;
        TextManager.instance.comptadorTrinxat = 29;
        TextManager.instance.comptadorComponents++;
    }
}
