using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; // El objeto que la cámara seguirá
    public float suavizado = 0.3f; // La suavidad del seguimiento de la cámara
    public Vector2 offset; // El desplazamiento de la cámara respecto al objetivo

    public string colliderTag = "CameraCollider"; // Tag de los colliders que afectan a la cámara

    private Vector3 minLimites; // Límites inferiores del área jugable
    private Vector3 maxLimites; // Límites superiores del área jugable

    void Start()
    {
        // Calcula los límites del área jugable
        CalculateCameraLimits();
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Calcula la posición objetivo de la cámara
            Vector3 objetivoPosicion = objetivo.position + (Vector3)offset;

            // Restringe la posición objetivo dentro de los límites del área jugable
            objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, minLimites.x, maxLimites.x);
            objetivoPosicion.y = Mathf.Clamp(objetivoPosicion.y, minLimites.y, maxLimites.y);

            // Actualiza la posición de la cámara
            transform.position = Vector3.Lerp(transform.position, objetivoPosicion, suavizado * Time.deltaTime);
        }
    }

    private void CalculateCameraLimits()
    {
        // Encuentra todos los colliders con el tag especificado
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        bool firstCollider = true;

        // Itera sobre los colliders para encontrar los límites
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(colliderTag))
            {
                if (firstCollider)
                {
                    // Si es el primer collider, establece los límites iniciales
                    minLimites = collider.bounds.min;
                    maxLimites = collider.bounds.max;
                    firstCollider = false;
                }
                else
                {
                    // Si no es el primer collider, amplía los límites según sea necesario
                    minLimites = Vector3.Min(minLimites, collider.bounds.min);
                    maxLimites = Vector3.Max(maxLimites, collider.bounds.max);
                }
            }
        }
    }
}
