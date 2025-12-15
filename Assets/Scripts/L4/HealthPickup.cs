using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 25;
    public AudioClip pickupSound;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStats stats = other.GetComponent<PlayerStats>();
        PlayerAudio audio = other.GetComponent<PlayerAudio>();

        if (stats == null || audio == null) return;

        stats.AddHealth(healAmount);
        audio.PlayPickup(pickupSound);

        Destroy(gameObject);
    }
}
