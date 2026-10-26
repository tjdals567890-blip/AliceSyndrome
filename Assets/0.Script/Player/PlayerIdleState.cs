using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerIdleState : IState
{
    private PlayerController controller;
    public PlayerIdleState(PlayerController controller)
    {
        this.controller = controller;
    }
    public void Enter()
    {
        
        controller.Stop();
    }
    public void Tick()
    {
        if (controller.HasMove)
            controller.Move();
    }
    public void Exit()
    {
    }
}
