using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public void Interact()
    {
        // Todo : 인벤토리 아이템 생성시 이곳에서 추가
        // ex) Additem(this);

        if(itemData != null)
        {
            Debug.Log($"{itemData.itemName}획득");
        }
        else
        {
            Debug.Log("아이템 데이터 찾을수 X");
        }

        Destroy(gameObject);
    }
}
