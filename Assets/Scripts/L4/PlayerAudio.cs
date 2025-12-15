using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayPickup(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }
}
