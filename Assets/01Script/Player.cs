using UnityEngine;

public class Player : MonoBehaviour
{
    private float interactDistance = 1f;
    private float moveSpeed = 5f;
    private Vector2 lastDir = Vector2.down;
    private Vector2 boxSize = new Vector2(0.7f, 0.7f);
    public LayerMask wallLayer;

    [Header("테스트용 임시 변수")]
    public bool hasWood = false;

    private void Update()
    {
        Move();
        Interact();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y).normalized;

        if(dir != Vector2.zero)
        {
            lastDir = dir;
        }

        float moveDistance = moveSpeed * Time.deltaTime;

        if (dir == Vector2.zero) return;
        
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize , 0f, dir, moveDistance, wallLayer);
        
        if(hit.collider == null)
        {
            transform.position += (Vector3)(dir * moveDistance);
        }
    }

    private void Interact()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDir, interactDistance);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
                else
                {
                    Debug.Log("상호작용 불가");
                }
            }
            else
            {
                Debug.Log("찾지 못함");
            }
        }
    }
}
