using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;

    public Interactable currentObject; // obiekt, na który patrzymy

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                currentObject = hit.collider.GetComponent<Interactable>();

                if (Input.GetKeyDown(interactKey))
                {
                    currentObject.StartInteraction(cam.transform, this.transform);
                }
            }
            else
            {
                currentObject = null;
            }
        }
        else
        {
            currentObject = null;
        }
    }
}
