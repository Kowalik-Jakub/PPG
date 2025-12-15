using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 2;
    public AudioClip pickupSound;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStats stats = other.GetComponent<PlayerStats>();
        PlayerAudio audio = other.GetComponent<PlayerAudio>();

        if (stats == null || audio == null) return;

        stats.AddAmmo(ammoAmount);
        audio.PlayPickup(pickupSound);

        Destroy(gameObject);
    }
}
