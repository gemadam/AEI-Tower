using UnityEngine;

public class Coin : MonoBehaviour
{
    public CollisionManager CollisionManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            CollisionManager.OnPlayerCollisionWithCoin(this, player);
        }
    }
}
