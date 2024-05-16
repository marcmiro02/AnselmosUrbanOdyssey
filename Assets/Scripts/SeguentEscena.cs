using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScene : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Introduccio");
        }
    }
    
}
