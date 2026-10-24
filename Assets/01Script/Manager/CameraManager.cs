using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [Header("전체 카메라 리스트")]
    public CinemachineCamera[] roomCameras;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ToSwitchRoom(int roomIndex)
    {
        for (int i = 0; i < roomCameras.Length; i++)
        {
            if(roomCameras[i] != null)
            {
                roomCameras[i].Priority = (i == roomIndex) ? 20 : 10;
            }
        }
    }
}
