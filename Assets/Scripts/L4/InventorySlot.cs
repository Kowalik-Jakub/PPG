using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI label;

    private InventoryItem item;
    private InventorySystem inventory;

    public void Setup(InventoryItem newItem, InventorySystem inv)
    {
        item = newItem;
        inventory = inv;

        icon.sprite = item.icon;
        icon.enabled = true;

        label.text = item.itemName;
    }

    public void OnClick()
    {
        if (item == null) return;
        inventory.UseItem(item);
    }
}
