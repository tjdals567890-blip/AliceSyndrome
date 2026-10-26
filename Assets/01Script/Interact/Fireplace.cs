using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    private bool isFireLit = false;

    [SerializeField] ItemData Firewood;

    public void Interact()
    {
        if(isFireLit)
        {
            Debug.Log("이미 난로 켜짐");
            return;
        }

        Player player = FindAnyObjectByType<Player>();

        if(Firewood != null && InventoryManager.Instance.HasItem(Firewood))
        {
            isFireLit = true;
            InventoryManager.Instance?.RemoveItem(Firewood);
            Debug.Log("불이 붙었다");

            // Todo : 난로 타는 이미지로 변경
        }
        else
        {
            Debug.Log("불을 붙일 무언가가 필요해보인다.");
            // Todo : 장작이 필요하다는 UI 띄우기
        }
    }
}
