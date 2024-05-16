using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite idleUpSprite;
    public Sprite idleDownSprite;
    public Sprite idleLeftSprite;
    public Sprite idleRightSprite;

    public Sprite[] upSprites;
    public Sprite[] downSprites;
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;

    public float moveSpeed = 3f; // Velocidad reducida

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 lastDirection = Vector2.zero;

    public bool movimentPermes = true;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Ajustar parámetros de Rigidbody para reducir el rebote
        rb.drag = 5f; // Ajustar la fricción lineal
        rb.angularDrag = 0.5f; // Ajustar la fricción angular
    }

    private void Update()
    {
        if (movimentPermes)
        {
            // Detecta la entrada del movimiento
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            movementInput = new Vector2(horizontalInput, verticalInput).normalized;

            // Cambia el sprite según la dirección
            UpdateSprite();
        }
    }

    private void FixedUpdate()
    {
        // Aplica la fuerza de movimiento basada en la entrada del jugador
        rb.velocity = movementInput * moveSpeed;
    }

    private void UpdateSprite()
    {
        if (movementInput != Vector2.zero)
        {
            // Cambiar el sprite según la dirección del movimiento
            if (movementInput.x > 0) // Derecha
                SetSprites(rightSprites, idleRightSprite);
            else if (movementInput.x < 0) // Izquierda
                SetSprites(leftSprites, idleLeftSprite);
            else if (movementInput.y > 0) // Arriba
                SetSprites(upSprites, idleUpSprite);
            else if (movementInput.y < 0) // Abajo
                SetSprites(downSprites, idleDownSprite);

            lastDirection = movementInput;
        }
        else
        {
            // Si no hay entrada, establecer sprite de reposo
            SetSpritesForLastDirection();
        }
    }

    private void SetSprites(Sprite[] directionSprites, Sprite idleSprite)
    {
        int index = Mathf.FloorToInt(Time.time * 10) % directionSprites.Length;
        spriteRenderer.sprite = directionSprites[index];
    }

    private void SetSpritesForLastDirection()
    {
        if (lastDirection.x > 0) // Derecha
            spriteRenderer.sprite = idleRightSprite;
        else if (lastDirection.x < 0) // Izquierda
            spriteRenderer.sprite = idleLeftSprite;
        else if (lastDirection.y > 0) // Arriba
            spriteRenderer.sprite = idleUpSprite;
        else if (lastDirection.y < 0) // Abajo
            spriteRenderer.sprite = idleDownSprite;
    }
}
