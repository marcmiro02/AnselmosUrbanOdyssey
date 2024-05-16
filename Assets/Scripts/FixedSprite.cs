using UnityEngine;

public class FixedSprite : MonoBehaviour
{

    public static FixedSprite instance;
    public Sprite newSprite; // Sprite que se asignará al colisionar con el jugador y presionar "X"
    public AudioSource soCapsa; // Sonido al cambiar el sprite

    private bool spriteChanged = false; // Bandera para controlar si el sprite ya ha sido cambiado
    private bool estemDins = false; // Bandera para indicar si el jugador está dentro del área de la caja

    private static int capsesObertes = 0; // Contador de cajas abiertas (estático para que sea compartido entre todas las instancias de FixedSprite)

    public bool obertura = false;

    private void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona es el jugador y si el sprite no ha sido cambiado
        if (other.CompareTag("Player") && !spriteChanged)
        {
            estemDins = true;
        }
    }

    private void Update()
    {
        if (estemDins && !spriteChanged && Input.GetKeyDown(KeyCode.X))
        {
            CambiarSprite();
        }
    }

    private void CambiarSprite()
    {
        // Verificar que se haya asignado un nuevo sprite desde el inspector
        if (newSprite != null)
        {
            // Obtener el componente SpriteRenderer del GameObject
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Asignar el nuevo sprite
            spriteRenderer.sprite = newSprite;

            // Reproducir sonido
            soCapsa.Play();

            // Establecer la bandera de sprite cambiado como verdadera
            spriteChanged = true;

            // Incrementar el contador solo si el sprite ha sido cambiado
            capsesObertes++;

            // Si se han abierto todas las cajas, destruir los objetos con el tag "VallesLaberint"
            if (capsesObertes == 6)
            {
                GameObject[] vallesLab = GameObject.FindGameObjectsWithTag("VallesLaberint");
                foreach (GameObject objecte in vallesLab)
                {
                    Destroy(objecte);
                }
                TextManager.instance.comptadorQuiosquero = 25;
                TextManager.instance.comptadorTrinxat = 19;

                obertura = true;

            }
        }
        else
        {
            // Mostrar un mensaje de advertencia si no se ha asignado un nuevo sprite
            Debug.LogWarning("¡No se ha asignado un nuevo sprite desde el inspector!");
        }
    }
}
