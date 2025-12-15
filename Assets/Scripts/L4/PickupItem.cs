using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public InventoryItem itemData;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InventorySystem>().AddItem(itemData);
            Destroy(gameObject);
        }
    }
}
