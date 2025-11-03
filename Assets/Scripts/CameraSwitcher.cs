using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera playerCamera;
    public Camera topDownCamera;
    private bool isTopDown = false;

    void Start()
    {
        playerCamera.enabled = true;
        topDownCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTopDown = !isTopDown;
            playerCamera.enabled = !isTopDown;
            topDownCamera.enabled = isTopDown;
        }
    }
}
