using UnityEngine;

/**
    Coin class
 */
public class Coin : MonoBehaviour
{
    public CollisionManager CollisionManager;   /*!< Reference to collision manager */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            CollisionManager.OnPlayerCollisionWithCoin(this, player);
        }
    }
}
