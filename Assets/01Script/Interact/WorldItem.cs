using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public void Interact()
    {
        if(itemData != null)
        {
            InventoryManager.Instance.AddItem(itemData);

            Debug.Log($"{itemData.itemName}획득");
        }
        else
        {
            Debug.Log("아이템 데이터 찾을수 X");
        }

        Destroy(gameObject);
    }
}
