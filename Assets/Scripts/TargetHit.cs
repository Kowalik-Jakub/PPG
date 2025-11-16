using UnityEngine;

public class TargetHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Tarcza trafiona!");
        }
    }
}
