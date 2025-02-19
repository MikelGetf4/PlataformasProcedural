using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float spawnDistance = 10f;
    public float despawnDistance = 15f;
    public float minGap = 2f;
    public float maxGap = 5f;


    public float minWidth = 1f;
    public float maxWidth = 3f;
    public float minHeight = -3f;
    public float maxHeight = -5f;

    public GameObject movingPlatformPrefab;

    private float lastXPosition;

    void Start()
    {
        lastXPosition = player.position.x;
        SpawnPlatform();
    }

    void Update()
    {

        if (player.position.x + spawnDistance > lastXPosition)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float gap = Random.Range(minGap, maxGap);
        lastXPosition += gap;


        float width = Random.Range(minWidth, maxWidth);


        int platformType = Random.Range(0, 2);
        GameObject platformPrefabToSpawn = platformPrefab;
        if (platformType == 1)
        {
            platformPrefabToSpawn = movingPlatformPrefab;
        }


        float height = Random.Range(minHeight, maxHeight);


        Vector3 spawnPosition = new Vector3(lastXPosition, height, 0);


        GameObject platform = Instantiate(platformPrefabToSpawn, spawnPosition, Quaternion.identity);


        platform.transform.localScale = new Vector3(width, platform.transform.localScale.y, platform.transform.localScale.z);


        if (platformType == 1)
        {
            platform.AddComponent<MovingPlatform>();
        }


        platform.AddComponent<PlatformDespawner>().player = player;
    }
}

public class PlatformDespawner : MonoBehaviour
{
    public Transform player;
    public float despawnDistance = 15f;

    void Update()
    {

        if (player != null && transform.position.x < player.position.x - despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}


public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Movemos la plataforma de un lado a otro
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(movement, 0, 0);
    }
}
