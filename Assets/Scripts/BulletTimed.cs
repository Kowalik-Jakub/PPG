using UnityEngine;

public class BulletTimed : MonoBehaviour
{
    public float speed = 50f;
    private bool hitSomething = false;
    private float destroyTimer = 0f;

    void Update()
    {
        if (!hitSomething)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
        {
            destroyTimer += Time.deltaTime;
            if (destroyTimer >= 5f)
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        hitSomething = true;
        speed = 0;
    }
}
