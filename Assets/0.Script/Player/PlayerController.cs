using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInputHandler input;
    [SerializeField] PlayerMovement move;

    IState current;
    PlayerIdleState idleState;
    PlayerMoveState moveState;

    public bool HasMove => input.hasMove;

    private void Awake()
    {
        if (input == null)
            input = GetComponent<PlayerInputHandler>();
        if(move == null)
            move = GetComponent<PlayerMovement>();

        idleState = new PlayerIdleState(this);
        moveState = new PlayerMoveState(this);
        ChangeState(idleState);
    }

    void Update()
    {
        input.ReadInput();
        current.Tick();
    }
    public void Walk()
    {
        move.SetMoveDirection(input.moveDirection, input.isSprint);
    }
    public void Stop()
    {
        move.SetMoveDirection(Vector2.zero, false);
    }
    void ChangeState(IState next)
    {
        if (current != null)
            current.Exit();
        current = next;
        current.Enter();
    }
    public void Idle()
    {
        ChangeState(idleState);
    }
    public void Move()
    {
        ChangeState(moveState);
    }
}
