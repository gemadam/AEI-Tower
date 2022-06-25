using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanBeControlled = true;

    public float VerticalSpeed = 10f;
    public float JumpSpeed = 100f;

    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate for physics
    void FixedUpdate()
    {
        if (CanBeControlled)
            MovementLogic();
    }

    void MovementLogic()
    {
        var position = transform.position;

        if (Input.GetKey("w") && _rigidBody.velocity.y == 0)
        {
            _rigidBody.AddForce(Vector3.up * JumpSpeed);
        }
        if (Input.GetKey("d"))
        {
            position.x += VerticalSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            position.x -= VerticalSpeed * Time.deltaTime;
        }

        transform.position = position;
    }
}
