using UnityEngine;
using UnityEngine.UI;

public class BafaradaContrasenya : MonoBehaviour
{
    public Text titol;
    public Text inputPassword;

    void Start()
    {
        gameObject.SetActive(false);
        titol.gameObject.SetActive(false);
        inputPassword.gameObject.SetActive(false);
    }

    public void ActivarElementos()
    {
        // Activa los elementos cuando se llame a este método
        gameObject.SetActive(true);
        titol.gameObject.SetActive(true);
        inputPassword.gameObject.SetActive(true);
    }

    public void DesactivarElementos()
    {
        // Desactiva los elementos cuando se llame a este método
        gameObject.SetActive(false);
        titol.gameObject.SetActive(false);
        inputPassword.gameObject.SetActive(false);
    }
}
