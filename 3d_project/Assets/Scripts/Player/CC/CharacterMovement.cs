using TMPro.EditorUtilities;
using Unity.VisualScripting;using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] float _rotationSpeed = 5f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Camera _cam;
    
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
}
private void Update()
{
    HandleJump();
}


private void HandleJump()
{
_isGrounded = _controller.isGrounded;
if (_isGrounded && _velocity.y < 0)
{
    _velocity.y = -2f;
}
if (Input.GetButtonDown("Jump")) && _isGrounded)
{
    _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
}
} 

private void FixedUpdate()
{
    HandleMovement();
}

private void HandleMovement()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    if (movement.magnitude > 0.1f)
    {
        Vector3 moveDirection = Quaternion.Euler(0,TMP_ColorGradientAssetMenu.)
    }
}