using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector3 _playerMovement;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _playerMovement = Vector3.right * Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, _playerMovement + transform.position,
            _speed * Time.deltaTime);
        if (_playerMovement.x < 0)
        {
            _sprite.flipX = true;
        }
        else if (_playerMovement.x > 0)
        {
            _sprite.flipX = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}

