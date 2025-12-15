using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float currentSpeed = 5f;

    public float jumpForce = 5f;
    public float crouchScale = 0.5f;
    private float originalHeight;
    private PlayerStats stats;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalHeight = transform.localScale.y;
        currentSpeed = walkSpeed;
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            Crouch();

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            if (stats.TryConsumeStamina(Time.deltaTime * (stats.staminaSprintDrain * 1.8f)))
            {
                float staminaPercent = stats.stamina / stats.maxStamina;
                currentSpeed = Mathf.Lerp(walkSpeed, sprintSpeed, staminaPercent);
            }
            else
            {
                currentSpeed = walkSpeed;
            }
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }

    public void SetAimSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void ResetWalkSpeed(float speed)
    {
        walkSpeed = speed;
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        Vector3 newVel = new Vector3(
            move.x * currentSpeed,
            rb.linearVelocity.y,
            move.z * currentSpeed
        );

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
