using System.Collections;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [Header("출구 위치")]
    public Transform targetSpawnPoint;

    [Header("이동할 방의 인덱스(vcam변경을 위해서 필요)")]
    public int targetRoomIndex;

    [Header("상호작용 여부(체크: z키 / 미체크: 닿으면 이동")]
    public bool isInteractive = false;

    [Header("잠금 설정")]
    public bool isLocked = false;
    public string lockMessage = "잠겨 있다";
    public string requiredKeyID;

    [Header("Fade In/Out")]
    public static CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.5f;

    private static bool isTransitioning = false;

    private void Start()
    {
        if(fadeCanvasGroup == null)
        {
            GameObject panel = GameObject.Find("FadePanel");
            if(panel != null )
            {
                fadeCanvasGroup = panel.GetComponent<CanvasGroup>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isInteractive && !isTransitioning && collision.CompareTag("Player"))
        {
            if(isLocked)
            {
                Debug.Log(lockMessage);
                return;
            }
            StartCoroutine(TransitionRoutine(collision.transform));
        }
    }

    public void Interact(Transform playerTransform)
    {
        if(isInteractive && !isTransitioning)
        {
            if(isLocked)
            {
                Player player = playerTransform.GetComponent<Player>();

                if (player != null)
                {
                    if(player.HasKey(requiredKeyID))
                    {
                        UnlockDoor();

                        // 플레이어 열쇠 소모
                        // player.ConsumeKey(requiredKeyID);

                        StartCoroutine(TransitionRoutine(playerTransform));
                    }
                    else
                    {
                        Debug.Log(lockMessage);
                        // Todo : 덜컹거리는 사운드 UI 출력
                    }
                }
                return;
            }

            StartCoroutine(TransitionRoutine(playerTransform));
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("문이 열렸다.");
    }

    private IEnumerator TransitionRoutine(Transform player)
    {
        isTransitioning = true;

        yield return StartCoroutine(Fade(0f, 1f));

        if(targetSpawnPoint != null)
        {
            player.position = targetSpawnPoint.position;
        }

        CameraManager.Instance?.ToSwitchRoom(targetRoomIndex);

        yield return new WaitForSeconds(0.05f);

        yield return StartCoroutine(Fade(1f, 0f));

        isTransitioning = false;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        if(fadeCanvasGroup == null) yield break;

        fadeCanvasGroup.blocksRaycasts = true;
        float elapsedTime = 0f;

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = endAlpha;

        if(endAlpha == 0f)
        {
            fadeCanvasGroup.blocksRaycasts = false;
        }
    }
}
