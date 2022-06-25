using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlatformPrefab;
    public CollisionManager CollisionManager;

    public bool EnableDestroyer = true;

    private GameObject Platform;

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

            var newPlatformPosition = new Vector2(Random.Range(-7f, 7f), platform.transform.position.y + 2);

            Platform = Instantiate(PlatformPrefab, newPlatformPosition, Quaternion.identity);

            Destroy(platform);
        }
    }
}
