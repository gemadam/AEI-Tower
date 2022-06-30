using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : MonoBehaviour
{
    public Player Player;
    public MainCamera Camera;
    public GameManager GameManager;
    public ICollection<GameObject> Platforms = new List<GameObject>();

    public GameObject PlatformPrefab;

    Vector3 _lastPosition = new Vector3();
    Rect _platformSpawningBounds = new Rect(-20, -5, 40, 5);


    public void RemovePlatforms()
    {
        foreach (GameObject p in Platforms)
            Destroy(p);

        Platforms.Clear();
    }

    public void RemovePlatform(GameObject platform)
    {
        Destroy(platform);
        Platforms.Remove(platform);
    }

    public void SpawnPlatform()
    {
        var position = new Vector2(Random.Range(_platformSpawningBounds.xMin, _platformSpawningBounds.xMax), Random.Range(_platformSpawningBounds.yMin, _platformSpawningBounds.yMax));

        var gameObject = Instantiate(PlatformPrefab, position, Quaternion.identity);

        gameObject.GetComponent<Platform>().CollisionManager = GameManager.CollisionManager;

        Platforms.Add(gameObject);

        _platformSpawningBounds.yMin += 5;
        _platformSpawningBounds.yMax += 5;
    }
}
