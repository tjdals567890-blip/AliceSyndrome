using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    private bool isFireLit = false;

    public void Interact()
    {
        if(isFireLit)
        {
            Debug.Log("이미 난로 켜짐");
            return;
        }

        Player player = FindAnyObjectByType<Player>();

        if(player != null && player.hasWood)
        {
            isFireLit = true;
            player.hasWood = false;
            Debug.Log("장작을 사용하여 난로에 불을 붙였습니다!");

            // Todo : 난로 타는 이미지로 변경
        }
        else
        {
            Debug.Log("장작이 없습니다.");
            // Todo : 장작이 필요하다는 UI 띄우기
        }
    }
}
