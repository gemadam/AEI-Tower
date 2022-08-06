using UnityEngine;

/**
    Destroyer class
 */
public class Destroyer : MonoBehaviour
{
    public CollisionManager CollisionManager;   /*!< Reference to collision manager */

    public bool EnableDestroyer = true;         /*!< Enables destroyer interactions */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!EnableDestroyer)
            return;
        else if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            CollisionManager.OnPlayerCollisionWithDestroyer(this, player);
        }
        else if (collision.gameObject.GetComponent<Platform>() != null)
        {
            var platform = collision.gameObject.GetComponent<Platform>();

            CollisionManager.OnPlatformCollisionWithDestroyer(this, platform);
        }
        else if (collision.gameObject.GetComponent<Coin>() != null)
        {
            var coin = collision.gameObject.GetComponent<Coin>();

            CollisionManager.OnCoinCollisionWithDestroyer(this, coin);
        }
    }
}
