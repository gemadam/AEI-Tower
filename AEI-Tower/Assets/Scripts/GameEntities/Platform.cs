using UnityEngine;

/**
    Platform class
 */
public class Platform : MonoBehaviour
{
    public CollisionManager CollisionManager;   /*!< Reference to collision manager */

    public bool CanBeDestroyed = true;          /*!< Can platform be destroyed */
    public int PointsForPlatform = 1;           /*!< Points assigned to platform */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            CollisionManager.OnPlayerCollisionWithPlatform(this, player, collision);
        }
    }
}
