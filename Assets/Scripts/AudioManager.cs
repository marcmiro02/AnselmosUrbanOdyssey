using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource currentAudioSource;

    public void StopCurrentAudio()
    {
        if (currentAudioSource != null && currentAudioSource.isPlaying)
        {
            currentAudioSource.Stop();
        }
    }

    public void PlayAudio(AudioSource audioSource)
    {
        currentAudioSource = audioSource;
        audioSource.Play();
    }
}
