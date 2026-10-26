using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction moveAction;
    InputAction sprintAction;

    public Vector2 moveDirection {  get; private set; }
    public bool hasMove {  get; private set; } //방향키를 눌렀는지 확인하는 값
    public bool isSprint {  get; private set; } //대쉬 키를 눌렀는지를 확인하는 값

    
    private void Awake()
    {
        if (inputActions == null)
            return;
        InputActionMap map = inputActions.FindActionMap("Player", true);
        moveAction = map.FindAction("Move", true);
        sprintAction = map.FindAction("Sprint", true);
        map.Enable();
    }
    private void OnDisable()
    {
        inputActions?.FindActionMap("Player", false)?.Disable();
    }
    public void ReadInput()
    {
        if (moveAction == null)
            return;

        Vector2 raw = moveAction.ReadValue<Vector2>();

        if (raw.sqrMagnitude > 1f)
            raw.Normalize();

        hasMove = raw.sqrMagnitude > 0f;
        moveDirection = raw;
        isSprint = sprintAction.IsPressed();
    }
    
}
