using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform slotContainer;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescText;

    private void Start()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged += RefreshUI;
        }

        RefreshUI();
        ClearDescription();
    }

    private void OnDestroy()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged -= RefreshUI;
        }
    }

    public void RefreshUI(ItemData changedItem = null)
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        var items = InventoryManager.Instance.Items;

        for (int i = 0; i < items.Count; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotContainer);
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();

            if(slot != null)
            {
                slot.Setup(items[i], this);
            }
        }
    }

    public void ShowItemDescription(ItemData item)
    {
        if (item != null)
        {
            itemNameText.text = item.itemName;
            itemDescText.text = item.itemDescription;
        }
    }

    private void ClearDescription()
    {
        itemNameText.text = "";
        itemDescText.text = "";
    }
}
