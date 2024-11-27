using UnityEngine;

namespace game


{
    public class InputController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private float _horizontalInput; 
        private bool _isGrounded;
        private bool _isJumping;
        public delegate void VerticalInputAction();

        public static VerticalInputAction verticalInputAction;
        
        void Update()
        {      
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                _isGrounded = true;
                _isJumping = false;
            }
            else
            {
                _isGrounded = false;
            }
            _horizontalInput = Input.GetAxis("Horizontal");
            
            
            if (Input.GetKeyDown(KeyCode.Space))
                if (_isGrounded)
            {
                verticalInputAction?.Invoke();
            }
            else if (!_isJumping)
            {
                _isJumping = true;
                verticalInputAction?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            Player.Instance.Move(_horizontalInput);
        }
    }

}

