using UnityEngine;
using UnityEngine.UI;

public class CrosshairRaycast : MonoBehaviour
{
    public Camera cam;
    public Image crosshair;
    public float rayDistance = 50f;
    public LayerMask interactMask; // tylko dla elementów z interakcj¹

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactMask))
        {
            crosshair.color = Color.red; // trafiony obiekt
        }
        else
        {
            crosshair.color = Color.white; // nic nie celujesz
        }
    }
}
