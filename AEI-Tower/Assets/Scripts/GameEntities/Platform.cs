using UnityEngine;

public class Platform : MonoBehaviour
{
    public CollisionManager CollisionManager;

    public float BounceFactor = 600f;
    public int PointsForPlatform = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

        // When player is falling down
        if (rigidBody != null && rigidBody.velocity.y <= 0)
        {
            rigidBody.AddForce(Vector3.up * BounceFactor);

            CollisionManager.OnPlayerCollisionWithPlatform(this, null);
        }
    }
}
