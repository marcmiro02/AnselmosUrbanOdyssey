using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objeto que la c�mara seguir�

    private Vector3 offset; // Distancia inicial entre la c�mara y el jugador
    private Vector2 currentMinLimits;
    private Vector2 currentMaxLimits;

    public int comptadorZones = 1;

    void Start()
    {
        if (target != null)
        {
            // Calcula la distancia inicial entre la c�mara y el jugador
            offset = transform.position - target.position;

            // Establece los l�mites de la zona inicial
            SetZoneLimits("Arribada-ZonaResidencial");
        }
    }

    void LateUpdate()
    {
        if (target != null && currentMinLimits != null && currentMaxLimits != null)
        {
            // Calcula la posici�n deseada de la c�mara con el offset
            Vector3 desiredPosition = target.position + offset;

            // Restringe la posici�n de la c�mara dentro de los l�mites de la zona actual
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, currentMinLimits.x, currentMaxLimits.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, currentMinLimits.y, currentMaxLimits.y);

            // Actualiza la posici�n de la c�mara
            transform.position = new Vector3(desiredPosition.x, desiredPosition.y, transform.position.z);
        }
    }

    // M�todo para establecer los l�mites seg�n el tag de la zona actual
    public void SetZoneLimits(string tag)
    {
        switch (tag)
        {
            case "Arribada-ZonaResidencial":
            case "Arribada-ZonaResidencial1":
            case "Arribada-ZonaResidencial2":
            case "Arribada-ZonaResidencial3":
                currentMinLimits = new Vector2(28.34f, -19.31f);
                currentMaxLimits = new Vector2(34.64f, -2.72f);
                break;
            case "Arribada-ZonaProves":
                currentMinLimits = new Vector2(56.37f, -24.29f);
                currentMaxLimits = new Vector2(61.65f, -10.73f);
                break;
            case "Arribada-CasesAdosades":
                currentMinLimits = new Vector2(38.41f, -40.3f);
                currentMaxLimits = new Vector2(44.66f, -37.71f);
                break;
            case "Arribada-CentreCiutat":
            case "Arribada-CentreCiutat1":
            case "Arribada-CentreCiutat2":
                currentMinLimits = new Vector2(-4.65f, -4.31f);
                currentMaxLimits = new Vector2(-1.35f, 11.29f);
                break;
            case "Arribada-CarrerMajor":
                currentMinLimits = new Vector2(-14.64f, 33.7f);
                currentMaxLimits = new Vector2(-4.36f, 37.29f);
                break;
            case "Arribada-BoscFuji":
                currentMinLimits = new Vector2(28.35f, 14.69f);
                currentMaxLimits = new Vector2(34.65f, 19.7f);
                break;
            case "Arribada-BarcoPirata":
            case "Arribada-BarcoPirata1":
            case "Arribada-BarcoPirata2":
                currentMinLimits = new Vector2(-8.5f, -36.27f);
                currentMaxLimits = new Vector2(-8.5f, -24.7f);
                break;
            case "PuntLaberint": //&& comptador = 1               
                currentMinLimits = new Vector2(77f, -30f);
                currentMaxLimits = new Vector2(107f, -4f);                                  
                break;
            case "PuntClasse": //&& comptador = 2
                currentMinLimits = new Vector2(127f, -22f);
                currentMaxLimits = new Vector2(136.6f, -9.58f);
                break;
            case "PuntPescar": //&& comptador = 3
                currentMinLimits = new Vector2(153f, -21f);
                currentMaxLimits = new Vector2(169f, -11f);
                break;
            case "ArribadaPorta":
                currentMinLimits = new Vector2(56.37f, -24.29f);
                currentMaxLimits = new Vector2(61.65f, -10.73f);
                break;
            default:
                Debug.LogWarning("Tag de zona desconocido.");
                break;
        }
    }

    // M�todo para teleportar la c�mara a una nueva posici�n
    // M�todo para teleportar la c�mara a una nueva posici�n
    // M�todo para teleportar la c�mara a una nueva posici�n
    public void TeleportCamera(Vector3 newPosition)
    {
        // Calcula la nueva posici�n deseada de la c�mara con el offset
        Vector3 desiredPosition = newPosition + offset;

        // Restringe la posici�n de la c�mara dentro de los l�mites de la zona actual
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, currentMinLimits.x, currentMaxLimits.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, currentMinLimits.y, currentMaxLimits.y);

        // Teleporta la c�mara a la nueva posici�n
        transform.position = new Vector3(desiredPosition.x, desiredPosition.y, transform.position.z);
    }


}
