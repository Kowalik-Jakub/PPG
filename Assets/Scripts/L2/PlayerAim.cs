using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform gun;
    public Camera playerCamera;
    public float normalFOV = 60f;
    public float aimFOV = 40f;
    public float aimSpeed = 10f;

    public float normalMoveSpeed = 5f;
    public float aimMoveSpeed = 2.5f;

    private bool isAiming = false;
    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();

        if (gun != null)
            gun.gameObject.SetActive(false);

        movement.walkSpeed = normalMoveSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;

            if (gun != null)
                gun.gameObject.SetActive(true);

            movement.SetAimSpeed(aimMoveSpeed);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;

            if (gun != null)
                gun.gameObject.SetActive(false);

            movement.ResetWalkSpeed(normalMoveSpeed);
        }

        float targetFOV = isAiming ? aimFOV : normalFOV;
        playerCamera.fieldOfView =
            Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * aimSpeed);
    }

    public bool IsAiming() => isAiming;
}
