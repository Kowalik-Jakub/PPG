using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 3f;
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.red;
        transform.localScale *= 2f;
        Destroy(gameObject, 0.2f);
    }

}
