using UnityEngine;

namespace game



{
    public class Player : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float _speed = 2.5f;
        [SerializeField] private float _jumpForce = 8f;
        
        private bool _isGrounded;
        private bool _doubleJump;
        
        private SpriteRenderer _sprite;
        private Rigidbody2D _rigidbody2D;
        
        public static Player Instance;

        private void OnEnable()
        {
            InputController.verticalInputAction += Jump;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.GetComponentInChildren<SpriteRenderer>();
        }
        
        internal void Move(float horizontalInput)
        {
            _rigidbody2D.linearVelocity = new Vector2(horizontalInput * _speed, _rigidbody2D.linearVelocityY);
        }

        internal void Jump()
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _jumpForce);
        }

        // internal bool CheckGround()
        // {
        //     var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
        //     if (hit.collider != null)
        //     {
        //         _isGrounded = true;
        //         _doubleJump = false;
        //     }
        //     else
        //     {
        //         _isGrounded = false;
        //     }
        //     // Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red);
        //     Debug.Log(_isGrounded);
        //     return hit.collider != null;
        // }

        void OnDisable()
        {
            InputController.verticalInputAction -= Jump;
        }
    }
}
