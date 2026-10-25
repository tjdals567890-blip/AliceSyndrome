using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rayDistance = 1.5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float walkSpeed = 3f; //이동속도
    [SerializeField] float sprintSpeed = 6f;

    Vector2 desiredVelocity;
    Vector2 aimDirection;
    void Awake()
    {
        if(rb==null)
            rb = GetComponent<Rigidbody2D>();
    }

    public void SetMoveDirection(Vector2 direction, bool sprinting)
    {
        float speed = sprinting? sprintSpeed : walkSpeed;
        desiredVelocity = direction * speed;

        if (direction.sqrMagnitude > 0f)
            aimDirection = direction;
    }
    void FixedUpdate()
    {
        Vector2 delta = desiredVelocity * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + delta);
        
        Debug.DrawRay(transform.position, aimDirection * rayDistance, Color.red);
    }
}
