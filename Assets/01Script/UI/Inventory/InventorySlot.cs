using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, ISelectHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Button slotButton;

    private ItemData currentItem;
    private InventoryUI inventoryUI;

    private void Awake()
    {
        if(slotButton == null)
        {
            slotButton = GetComponent<Button>();
        }
    }

    public void Setup(ItemData item, InventoryUI ui)
    {
        currentItem = item;
        inventoryUI = ui;

        if(currentItem != null && currentItem.itemIcon != null)
        {
            iconImage.sprite = currentItem.itemIcon;
            iconImage.gameObject.SetActive(true);

            if (slotButton != null) slotButton.interactable = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.gameObject.SetActive(false);

            if (slotButton != null) slotButton.interactable = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(inventoryUI != null && currentItem != null)
        {
            inventoryUI.ShowItemDescription(currentItem);
        }
    }
}
