using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Ustawienia zoomu")]
    public Transform target;       
    public float minDistance = 2f; 
    public float maxDistance = 10f; 
    public float zoomSpeed = 5f;   

    private float currentDistance;

    void Start()
    {
        if (target != null)
            currentDistance = Vector3.Distance(transform.position, target.position);
        else
            Debug.LogWarning("CameraZoom: Nie przypisano obiektu target!");
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            currentDistance -= scroll * zoomSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            Vector3 direction = (transform.position - target.position).normalized;
            transform.position = target.position + direction * currentDistance;
        }
    }
}
