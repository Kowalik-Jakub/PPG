using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public int value;
    public ItemType type;
}

public enum ItemType
{
    Health,
    Ammo,
    Stamina
}
