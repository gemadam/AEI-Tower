using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanBeControlled = true;

    private Rigidbody2D _rigidBody;
    private float _moveInput;
    private float _speed = 10f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate for physics
    void FixedUpdate()
    {
        if (CanBeControlled)
        {
            _moveInput = Input.GetAxis("Horizontal");

            _rigidBody.velocity = new Vector2(_moveInput * _speed, _rigidBody.velocity.y);
        }
    }
}
