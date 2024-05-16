using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna tu VideoPlayer en el Inspector
    public string nextSceneName; // Asigna el nombre de la siguiente escena en el Inspector

    void Start()
    {
        // Asegúrate de que el VideoPlayer esté asignado
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Verifica si el VideoPlayer está correctamente asignado
        if (videoPlayer != null)
        {
            // Agrega un listener para el evento loopPointReached del VideoPlayer
            videoPlayer.loopPointReached += LoadNextScene;
        }
        else
        {
            Debug.LogError("VideoPlayer no está asignado en " + gameObject.name);
        }
    }

    void LoadNextScene(VideoPlayer vp)
    {
        // Carga la siguiente escena asignada
        SceneManager.LoadScene("Credits");
    }
}
