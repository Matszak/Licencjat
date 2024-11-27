using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;

    // radius around sphere where it detects collisions
    private float _shellRadius = 0.01f;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];

    private Vector2 _groundNormal;
    public float minGroundNormalY = .65f;
    
    
    public Vector2 velocity;
    private Vector2 targetVelocity;

    private float _minMoveDistance = 0.001f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        targetVelocity.x = context.ReadValue<float>();
        targetVelocity.x *= maxSpeed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
 
    }

    private void FixedUpdate()
    {
  
        velocity += Physics2D.gravity * gravityModifier * Time.deltaTime;
     
  
        _isGrounded = false;

        velocity.x = targetVelocity.x;
        

        var deltaPosition = velocity * Time.deltaTime;

        var moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);

        var move = moveAlongGround * deltaPosition.x;
        
        PerformMovement(move,false);
       
        move = Vector2.up * deltaPosition.y;

        PerformMovement(move, true);
    }

    private void PerformMovement(Vector2 move, bool yMovement)
    {
        var distance = move.magnitude;
        
        if (distance > _minMoveDistance)
        {
            var count = _rigidbody2D.Cast(velocity,_hitBuffer, distance + _shellRadius);
            for (var i = 0; i < count; i++)
            {
                var currentNormal = _hitBuffer[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    _isGrounded = true;
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                if (_isGrounded)
                {
                    var projection = Vector2.Dot(velocity, currentNormal);
                    if (projection > 0)
                    {
                        velocity -= projection * currentNormal;
                    }

                    velocity.y = 0;
    
                }
                else
                {
                    //We are airborne, but hit something, so cancel vertical up and horizontal velocity.
                    velocity.x *= 0;
                    velocity.y = Mathf.Min(velocity.y, 0);
                }
                var modifiedDistance = _hitBuffer[i].distance - _shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rigidbody2D.position += move.normalized * distance;
    }
    
}
