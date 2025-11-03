using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float crouchScale = 0.5f;
    private float originalHeight;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalHeight = transform.localScale.y;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
            Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Crouch();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 newVel = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
        rb.linearVelocity = newVel;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void Crouch()
    {
        isCrouching = !isCrouching;
        float newY = isCrouching ? originalHeight * crouchScale : originalHeight;
        transform.localScale = new Vector3(transform.localScale.x, newY, transform.localScale.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
