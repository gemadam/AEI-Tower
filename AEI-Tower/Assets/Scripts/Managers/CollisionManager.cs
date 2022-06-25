using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameManager GameManager;
    public ScoreManager ScoreManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerCollisionWithPlatform(Platform platform, Player player)
    {
        ScoreManager.AddPoints(platform.PointsForPlatform);

        platform.PointsForPlatform = 0;
    }

    public void OnPlayerCollisionWithDestroyer(Destroyer destroyer, Player player)
    {
        GameManager.OnGameOver();
    }
}
