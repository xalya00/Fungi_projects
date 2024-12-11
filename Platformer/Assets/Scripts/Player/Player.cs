using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Movement")] 
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 7f;
  
    private int _jumpingCount;
    private bool _isFalling;
    private int _health = 100;
    private bool _isDoubleJumping;
    
    
    [SerializeField] private float _groundCheckRadius = 1.1f;
    private bool _isGround;
    [SerializeField] private LayerMask _mask;
    private Ray _ray;
    
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2D;

    
    public static Player Instance;
    
    
    private void Awake() => Instance = this;
    
    private void Start()
    { 
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckGround();
        VerticalSpeed();
    }

    internal void Move(float value)
    {
        _sprite.flipX = value < 0 ? true : false;
        
        _rb2D.linearVelocity = new Vector2(value * _speed, _rb2D.linearVelocityY);
        _animator.SetBool("IsRun", Mathf.Abs(_rb2D.linearVelocity.x) > 0.01f);
    }
    
    internal void Jump()
    {
        if (CheckGround())
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
            _animator.SetTrigger("Jumping");
        }
    }

    private void VerticalSpeed()
    {
        _animator.SetBool("isFall", _isFalling);
        if (_rb2D.linearVelocity. y < 0)
        {
           _animator.SetBool("IsFall", true);
        }
    }

    public bool CheckGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
        if (hit.collider != null) ;
        {
            _isFalling = false;
            return true;
        }
        return false;
    }

    void DoubleJump(bool obj)
    {
        _isDoubleJumping = obj;
    }
    
}
