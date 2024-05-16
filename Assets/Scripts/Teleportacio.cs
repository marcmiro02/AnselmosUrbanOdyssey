using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Teleportacion : MonoBehaviour
{
    public Transform Arribada; // El punto de llegada al que se teletransportará el jugador
    public Text textoZona; // Referencia al objeto de texto en pantalla para mostrar el nombre de la zona
    public float fadeInDuration = 1f; // Duración de la aparición del texto
    public float fadeOutDuration = 1f; // Duración de la disolución del texto

    private bool firstZoneChange = true;
    private CameraFollow cameraFollow; // Referencia al script CameraFollow para establecer los límites de la cámara

    private AudioManager audioManager;

    private int comptadorZona = 1;
    private bool finalPorta = false;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>(); // Encontrar el AudioManager en la escena
        cameraFollow = Camera.main.GetComponent<CameraFollow>(); // Obtener el script CameraFollow
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona es el jugador
        {
            if (firstZoneChange)
            {
                // Detiene la reproducción del audio asociado a la cámara
                Camera.main.GetComponent<AudioSource>().Stop();
                firstZoneChange = false;
            }
            DetenerAudioZonaActual(); // Detiene la pista de audio de la zona actual

            // Teletransportar al jugador y actualizar la cámara
            TeletransportarJugador(other.transform);
        }
    }

    private void TeletransportarJugador(Transform jugadorTransform)
    {
        if (gameObject.tag == "Porta")
        {
            if (comptadorZona == 1)
            {
                comptadorZona = 2;
                ProvaCompletada.instance.comptadorProves = 1;
                TextManager.instance.comptadorQuiosquero = 25;
                TextManager.instance.comptadorTrinxat = 19;
            }
            else if (comptadorZona == 2)
            {
                Arribada = GameObject.FindGameObjectWithTag("PuntClasse").transform;
                comptadorZona = 3;
                ProvaCompletada.instance.comptadorProves = 2;
                TextManager.instance.comptadorQuiosquero = 30;
                TextManager.instance.comptadorTrinxat = 20;
            }
            else if (comptadorZona == 3)
            {
                Arribada = GameObject.FindGameObjectWithTag("PuntPescar").transform;
                comptadorZona++;
                ProvaCompletada.instance.comptadorProves = 3;
                TextManager.instance.comptadorQuiosquero = 35;
                TextManager.instance.comptadorTrinxat = 21;

                finalPorta = true;
            }
            StartCoroutine(PausarUnSegonet());
            jugadorTransform.position = Arribada.position;
            cameraFollow.TeleportCamera(Arribada.position);
            cameraFollow.SetZoneLimits(Arribada.tag); // Corregido: Se establece el tag de la zona

            // Reproducir audio de la nueva zona
            ReproducirAudioZona();

            // Mostrar texto de la zona
            MostrarTextoZona();
            if (finalPorta)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            jugadorTransform.position = Arribada.position; // Teletransporta al jugador al punto de llegada

            // Teletransportar la cámara al punto de llegada y actualizar los límites
            cameraFollow.TeleportCamera(Arribada.position);
            cameraFollow.SetZoneLimits(Arribada.tag); // Corregido: Se establece el tag de la zona

            // Reproducir audio de la nueva zona
            ReproducirAudioZona();

            // Mostrar texto de la zona
            MostrarTextoZona();
        }
    }

    private void ReproducirAudioZona()
    {
        if (audioManager != null && Arribada != null)
        {
            AudioSource audioSourceNueva = Arribada.GetComponent<AudioSource>();
            if (audioSourceNueva != null)
            {
                audioManager.PlayAudio(audioSourceNueva);
            }
        }
    }

    private void DetenerAudioZonaActual()
    {
        if (audioManager != null)
        {
            audioManager.StopCurrentAudio();
        }
    }

    private void MostrarTextoZona()
    {
        if (textoZona != null && Arribada != null)
        {
            textoZona.text = Arribada.GetComponentInChildren<Text>().text;

            // Inicia la animación de aparición y disolución del texto
            StartCoroutine(FadeText(fadeInDuration, fadeOutDuration));
        }
    }

    private System.Collections.IEnumerator FadeText(float fadeInDuration, float fadeOutDuration)
    {
        Color originalColor = textoZona.color;
        Color fadeInColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Color completamente opaco
        Color fadeOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Color completamente transparente

        // Aparición rápida del texto
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            textoZona.color = Color.Lerp(originalColor, fadeInColor, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Espera un momento antes de iniciar la disolución
        yield return new WaitForSeconds(1f);

        // Disolución gradual del texto
        timer = 0f;
        while (timer < fadeOutDuration)
        {
            textoZona.color = Color.Lerp(fadeInColor, fadeOutColor, timer / fadeOutDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Mantener el texto desvanecido
        textoZona.color = fadeOutColor;
    }

    IEnumerator PausarUnSegonet()
    {
        yield return new WaitForSeconds(1.0f);
    }
}