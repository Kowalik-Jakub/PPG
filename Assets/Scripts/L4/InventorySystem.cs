using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public PlayerStats stats;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
        Debug.Log("Dodano do ekwipunku: " + item.itemName);
    }

    public void UseItem(InventoryItem item)
    {
        switch (item.type)
        {
            case ItemType.Health:
                stats.AddHealth(item.value);
                break;

            case ItemType.Ammo:
                stats.AddAmmo(item.value);
                break;

            case ItemType.Stamina:
                stats.stamina = Mathf.Clamp(stats.stamina + item.value, 0, stats.maxStamina);
                break;
        }

        items.Remove(item);
        Debug.Log("U¿yto przedmiotu: " + item.itemName);
    }
}
