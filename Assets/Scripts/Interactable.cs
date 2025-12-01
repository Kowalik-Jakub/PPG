using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isHeld = false;
    public float followSpeed = 10f;

    private Transform cameraTransform;
    private Transform playerTransform;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartInteraction(Transform cam, Transform player)
    {
        isHeld = !isHeld;

        if (isHeld)
        {
            cameraTransform = cam;
            playerTransform = player;

            rb.useGravity = false;
            rb.freezeRotation = true;
        }
        else
        {
            rb.useGravity = true;
            rb.freezeRotation = false;

            cameraTransform = null;
            playerTransform = null;
        }

        Debug.Log("Interakcja z obiektem: " + gameObject.name);
    }

    void FixedUpdate()
    {
        if (isHeld && cameraTransform != null && playerTransform != null)
        {
            Vector3 targetPos =
                playerTransform.position +
                Vector3.up * 1.5f +    
                playerTransform.forward * 0.5f; 

            rb.MovePosition(Vector3.Lerp(
                rb.position,
                targetPos,
                followSpeed * Time.fixedDeltaTime
            ));

            Vector3 lookDir = cameraTransform.position - transform.position;
            if (lookDir != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.Lerp(
                    rb.rotation,
                    Quaternion.LookRotation(-lookDir),
                    followSpeed * Time.fixedDeltaTime
                ));
            }
        }
    }
}
