using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltarEscenaCredits : MonoBehaviour
{

    private bool jaNoToca = false;
    // Update is called once per frame
    void Update()
    {
        if (jaNoToca)
        {
            SceneManager.LoadScene("FinalMenu");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jaNoToca = true;
        }
    }
}
