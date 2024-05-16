using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; // El objeto que la c�mara seguir�
    public float suavizado = 0.3f; // La suavidad del seguimiento de la c�mara
    public Vector2 offset; // El desplazamiento de la c�mara respecto al objetivo

    public string colliderTag = "CameraCollider"; // Tag de los colliders que afectan a la c�mara

    private Vector3 minLimites; // L�mites inferiores del �rea jugable
    private Vector3 maxLimites; // L�mites superiores del �rea jugable

    void Start()
    {
        // Calcula los l�mites del �rea jugable
        CalculateCameraLimits();
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Calcula la posici�n objetivo de la c�mara
            Vector3 objetivoPosicion = objetivo.position + (Vector3)offset;

            // Restringe la posici�n objetivo dentro de los l�mites del �rea jugable
            objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, minLimites.x, maxLimites.x);
            objetivoPosicion.y = Mathf.Clamp(objetivoPosicion.y, minLimites.y, maxLimites.y);

            // Actualiza la posici�n de la c�mara
            transform.position = Vector3.Lerp(transform.position, objetivoPosicion, suavizado * Time.deltaTime);
        }
    }

    private void CalculateCameraLimits()
    {
        // Encuentra todos los colliders con el tag especificado
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        bool firstCollider = true;

        // Itera sobre los colliders para encontrar los l�mites
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(colliderTag))
            {
                if (firstCollider)
                {
                    // Si es el primer collider, establece los l�mites iniciales
                    minLimites = collider.bounds.min;
                    maxLimites = collider.bounds.max;
                    firstCollider = false;
                }
                else
                {
                    // Si no es el primer collider, ampl�a los l�mites seg�n sea necesario
                    minLimites = Vector3.Min(minLimites, collider.bounds.min);
                    maxLimites = Vector3.Max(maxLimites, collider.bounds.max);
                }
            }
        }
    }
}
