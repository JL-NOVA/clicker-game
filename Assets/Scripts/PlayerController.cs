using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // COPY UNDER THIS LINE
    public Transform LeftGroundCheck;
    public Transform RightGroundCheck;
    public LayerMask GroundLayer;

    bool IsGrounded()
    {
        var leftCheck = Physics2D.OverlapCircle(LeftGroundCheck.position, 0.1f, GroundLayer);
        var rightCheck = Physics2D.OverlapCircle(RightGroundCheck.position, 0.1f, GroundLayer);
        return leftCheck || rightCheck;
    }

    public void OnJump()
    {
        if(IsGrounded())
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}