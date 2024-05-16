using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del NPC
    public Sprite spriteRight; // Sprite cuando se mueve hacia la derecha
    public Sprite spriteLeft; // Sprite cuando se mueve hacia la izquierda

    public GameObject nodeDreta;
    public GameObject nodeEsquerra;

    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Establecer el sprite inicial
        spriteRenderer.sprite = spriteRight;
    }

    void Update()
    {
        // Movimiento horizontal
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            spriteRenderer.sprite = spriteRight; // Establecer el sprite de movimiento hacia la derecha
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            spriteRenderer.sprite = spriteLeft; // Establecer el sprite de movimiento hacia la izquierda
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        // Verificar si ha colisionado con un duckNode
        if (collision.CompareTag("duckNode"))
        {
            if ((collision.gameObject == nodeDreta && movingRight) || (collision.gameObject == nodeEsquerra && !movingRight))
            {
                // Cambiar la dirección
                movingRight = !movingRight;

                // Cambiar el sprite según la dirección
                if (movingRight)
                {
                    spriteRenderer.sprite = spriteRight;
                }
                else
                {
                    spriteRenderer.sprite = spriteLeft;
                }
            }
        }
    }
}
