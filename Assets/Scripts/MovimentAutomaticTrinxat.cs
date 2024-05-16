using UnityEngine;
using System.Collections;

public class MovimentAutomaticTrinxat : MonoBehaviour
{
    public float velocidadMovimiento = 2.0f;
    public Transform[] puntosDestino;
    private int indicePuntoDestino = 0;
    private bool movimientoIniciado = false;
    private bool pausaIniciada = false;

    public Sprite[] spritesPosicionActualAPunto1; // Sprites para el movimiento de la posición actual al punto 1
    public Sprite[] spritesPunto1APunto2; // Sprites para el movimiento del punto 1 al 2
    public Sprite[] spritesPunto2APunto3; // Sprites para el movimiento del punto 2 al 3
    public Sprite[] spritesPunto3APunto4; // Sprites para el movimiento del punto 3 al 4

    private SpriteRenderer spriteRenderer;
    private Sprite[] spritesActuales;
    private int spriteIndex = 0;
    private Sprite spriteOriginal; // Sprite original del objeto
    public float tiempoEntreSprites = 0.2f;
    private float tiempoUltimoSprite = 0.0f;

    public GameObject bocadilloUI;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Guardar el sprite original del objeto
        spriteOriginal = spriteRenderer.sprite;
    }

    void Update()
    {
        // Comenzar el movimiento cuando acabarTextTrinxat es verdadero y no se ha iniciado el movimiento
        if (TextManager.instance.acabarTextTrinxat && !movimientoIniciado && !pausaIniciada)
        {
            // Iniciar la pausa
            StartCoroutine(PausaPorSegundo());
            pausaIniciada = true;
        }

        // Solo continuar si el movimiento ha sido iniciado
        if (movimientoIniciado)
        {
            // Mover el personaje hacia el siguiente punto de destino
            MoverHaciaPuntoSiguiente();
            // Alternar entre los sprites de la animación de caminar
            AlternarSpritesCaminando();
        }
    }

    void MoverHaciaPuntoSiguiente()
    {
        // Verificar si hay más puntos de destino para moverse
        if (indicePuntoDestino < puntosDestino.Length)
        {
            // Calcular la dirección hacia el siguiente punto de destino
            Vector2 direccion = ((Vector2)puntosDestino[indicePuntoDestino].position - (Vector2)transform.position).normalized;

            // Mover el objeto en dirección al punto de destino con velocidad constante
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

            // Verificar si ha llegado al punto de destino
            if (Vector2.Distance(transform.position, puntosDestino[indicePuntoDestino].position) < 0.1f)
            {
                // Incrementar el índice para apuntar al siguiente punto de destino
                indicePuntoDestino++;

                // Verificar si hemos llegado al último punto de destino
                if (indicePuntoDestino >= puntosDestino.Length)
                {
                    // Teletransportar el objeto a las coordenadas especificadas
                    TextManager.instance.comptadorTrinxat = 13;
                    transform.position = new Vector3(-12f, -34f, -1f);
                    // Detener el movimiento y restaurar el sprite original
                    DetenerMovimiento();
                    return;
                }

                // Asignar los sprites correspondientes al punto de destino actual
                AsignarSpritesActuales();
            }
        }
    }

    void DetenerMovimiento()
    {
        // Restaurar el sprite original del objeto
        spriteRenderer.sprite = spriteOriginal;
        // Detener el movimiento
        movimientoIniciado = false;
    }

    void AlternarSpritesCaminando()
    {
        // Verificar si los sprites actuales están asignados y hay al menos dos sprites
        if (spritesActuales != null && spritesActuales.Length >= 2)
        {
            // Verificar si es el momento de cambiar de sprite
            if (Time.time - tiempoUltimoSprite > tiempoEntreSprites)
            {
                // Cambiar al siguiente sprite en la animación de caminar
                spriteRenderer.sprite = spritesActuales[spriteIndex];

                // Incrementar el índice del sprite
                spriteIndex = (spriteIndex + 1) % spritesActuales.Length;

                // Actualizar el tiempo del último sprite cambiado
                tiempoUltimoSprite = Time.time;
            }
        }
    }

    void AsignarSpritesActuales()
    {
        // Determinar los sprites correspondientes según el punto de destino actual
        switch (indicePuntoDestino)
        {
            case 0:
                spritesActuales = spritesPosicionActualAPunto1;
                break;
            case 1:
                spritesActuales = spritesPunto1APunto2;
                break;
            case 2:
                spritesActuales = spritesPunto2APunto3;
                break;
            case 3:
                spritesActuales = spritesPunto3APunto4;
                break;
            default:
                // Si el índice de punto de destino está fuera de rango, no asignar sprites
                spritesActuales = null;
                break;
        }

        // Reiniciar el índice del sprite
        spriteIndex = 0;

        // Forzar la alternancia de sprites en el primer fotograma después de iniciar el movimiento
        AlternarSpritesCaminando();
    }

    IEnumerator PausaPorSegundo()
    {
        // Esperar 3 segundos antes de continuar
        yield return new WaitForSeconds(3.0f);

        // Marcar la pausa como completada y comenzar el movimiento
        pausaIniciada = false;
        movimientoIniciado = true;

        // Asignar los sprites correspondientes al punto de destino actual
        AsignarSpritesActuales();

        // Ocultar el bocadillo
        if (bocadilloUI != null)
        {
            var bocadilloUIComponent = bocadilloUI.GetComponent<BocadilloUI>();
            bocadilloUI.SetActive(false); // Desactivar el GameObject del bocadillo
            bocadilloUIComponent.textoText.gameObject.SetActive(false); // Ocultar el texto
            bocadilloUIComponent.LimpiarTexto();
        }
    }
}
