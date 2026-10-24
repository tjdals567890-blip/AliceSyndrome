using UnityEngine;

public class PlayerMoveState : IState
{
    private PlayerController controller;
    public PlayerMoveState(PlayerController controller)
    {
        this.controller = controller;
    }
    public void Enter()
    {
        controller.Walk();
    }
    public void Exit() { }
    public void Tick()
    {
        if (!controller.HasMove)
        {
            controller.Idle();
            return;
        }
        controller.Move();
    }
}
