using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    public Vector2 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        velocity.x = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
 

    private void FixedUpdate()
    {
        _rigidbody2D.position += velocity * (maxSpeed * Time.deltaTime);
        _isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        const float groundCheckDistance = 0.1f;
        var hitCount = _rigidbody2D.Cast(Vector2.down, new RaycastHit2D[1], groundCheckDistance);

        return hitCount > 0;
    }
}