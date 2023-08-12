using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private LayerMask _jumpableGround;
    [SerializeField] private AudioSource _jumpSoundEffect;
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 14f;

    private Rigidbody2D _rigitBody2D;
    private SpriteRenderer _sprite;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private float _directionX = 0f;


    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

 

    void Start()
    {
        _rigitBody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _sprite = _rigitBody2D.GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _rigitBody2D.velocity = new Vector2(_directionX * _moveSpeed, _rigitBody2D.velocity.y);


        if (Input.GetButtonDown("Jump")&& IsGrounded())
            
        {
            _jumpSoundEffect.Play();
            _rigitBody2D.velocity = new Vector2(_rigitBody2D.velocity.x, _jumpForce);
        }

        UpdateAnomationState();

    }
    private void UpdateAnomationState()
    {
        MovementState state;
        if (_directionX > 0f)
        {
            state = MovementState.running;
            _sprite.flipX = false;
        }

        else if (_directionX < 0f)
        {
            state = MovementState.running;
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (_rigitBody2D.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_rigitBody2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }



        _animator.SetInteger("state", (int)state);

    }
    private bool IsGrounded()
    {
         return Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
        
    }


}
