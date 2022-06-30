using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitiesManager : MonoBehaviour
{
    public Player Player;
    public MainCamera Camera;
    public GameManager GameManager;
    public ICollection<GameObject> Platforms = new List<GameObject>();

    public GameObject PlatformPrefab;

    Vector3 _lastPosition = new Vector3();
    Rect _platformSpawningBounds = new Rect(-20, -5, 40, 5);


    public void ResetState()
    {
        foreach (GameObject p in Platforms)
            Destroy(p);

        Platforms.Clear();

        _platformSpawningBounds = new Rect(-20, -5, 40, 5);
    }

    public void RemovePlatform(GameObject platform)
    {
        Destroy(platform);
        Platforms.Remove(platform);
    }

    public void SpawnPlatform()
    {
        _lastPosition.x = Random.Range(
            Math.Max(_platformSpawningBounds.xMin, _lastPosition.x - 10),
            Math.Min(_platformSpawningBounds.xMax, _lastPosition.x + 10)
        );
        _lastPosition.y = Random.Range(_platformSpawningBounds.yMin, _platformSpawningBounds.yMax);

        var gameObject = Instantiate(PlatformPrefab, _lastPosition, Quaternion.identity);

        gameObject.GetComponent<Platform>().CollisionManager = GameManager.CollisionManager;

        Platforms.Add(gameObject);

        _platformSpawningBounds.yMin = _lastPosition.y + 4;
        _platformSpawningBounds.yMax = _lastPosition.y + 9;
    }
}
