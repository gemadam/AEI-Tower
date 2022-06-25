using UnityEngine;

public class CollisionManager : MonoBehaviour
{
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
}
