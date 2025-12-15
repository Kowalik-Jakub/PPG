using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public InventorySystem inventory;

    public Transform slotsParent;  
    public InventorySlot slotPrefab; 

    bool isOpen = false;

    void Start()
    {
        Close();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen) Close();
            else Open();
        }
    }

    void Open()
    {
        isOpen = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Refresh();
    }

    void Close()
    {
        isOpen = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Refresh()
    {
        foreach (Transform child in slotsParent)
            Destroy(child.gameObject);

        foreach (InventoryItem item in inventory.items)
        {
            InventorySlot slot =
                Instantiate(slotPrefab, slotsParent);

            slot.Setup(item, inventory);
        }
    }
}
