using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    InventoryItem item;
    InventorySystem inventory;

    public void Assign(InventoryItem newItem, InventorySystem inv)
    {
        item = newItem;
        inventory = inv;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Use()
    {
        if (item == null) return;
        inventory.UseItem(item);
        icon.enabled = false;
        item = null;
    }
}
