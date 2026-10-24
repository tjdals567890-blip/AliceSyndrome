using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float walkSpeed = 3f; //이동속도
    [SerializeField] float sprintSpeed = 6f;

    float facingAngle; //플레이어가 바라보는 각도;
    Vector2 desiredVelocity;
    void Awake()
    {
        if(rb==null)
            rb = GetComponent<Rigidbody2D>();
    }

    public void SetMoveDirection(Vector2 direction, bool sprinting)
    {
        float speed = sprinting? sprintSpeed : walkSpeed;
        desiredVelocity = direction * speed;

        if(direction.sqrMagnitude>0f)
            facingAngle = -Mathf.Atan2(direction.x, direction.y) *Mathf.Rad2Deg;
    }
    void FixedUpdate()
    {
        Vector2 delta = desiredVelocity * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + delta);

        rb.MoveRotation(facingAngle);
    }
}
