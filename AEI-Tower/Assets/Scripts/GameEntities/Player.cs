using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    public bool CanBeControlled = true;

    public Vector2 Speed = new Vector2(15, 35);
    public Vector2 InitialPosition = new Vector2(4.1638f, -1.91f);

    private Rigidbody2D _rigidBody;
    private PlayerAnimation _animation;
    private Vector2 _movement = new Vector2();


    private void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody2D>();
        _animation = this.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (CanBeControlled)
            MovementLogic();
        else
            _rigidBody.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _movement;
    }

    void MovementLogic()
    {
        _movement = _rigidBody.velocity;

        if (_movement.y == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _animation.SetAnimation(EnumPlayerAnimation.Jump);
                _movement.y = Speed.y;
            }
            else
                _animation.SetAnimation(EnumPlayerAnimation.Idle);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _movement.x = Speed.x;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movement.x = -Speed.x;
        }
        else
            _movement.x = 0;
    }

    public void RunForrestRun()
    {
        _rigidBody.velocity = new Vector2(0, Speed.y);
    }

    public void Reset()
    {
        if (_rigidBody == null)
            return;

        _rigidBody.position = InitialPosition;
    }
}
