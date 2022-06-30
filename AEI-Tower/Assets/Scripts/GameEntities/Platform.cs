using UnityEngine;

public class Platform : MonoBehaviour
{
    public CollisionManager CollisionManager;

    public bool CanBeDestroyed = true;
    public int PointsForPlatform = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            CollisionManager.OnPlayerCollisionWithPlatform(this, player, collision);
        }
    }
}
