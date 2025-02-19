using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDistance = 10f;
    public float minGap = 3f;
    public float maxGap = 7f;
    public float minHeight = 2f;
    public float maxHeight = 5f;

    private float lastXPosition;

    void Start()
    {
        lastXPosition = player.position.x;
        SpawnObstacle();
    }

    void Update()
    {
        if (player.position.x + spawnDistance > lastXPosition)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        float gap = Random.Range(minGap, maxGap);
        lastXPosition += gap;


        float height = Random.Range(minHeight, maxHeight);


        Vector3 spawnPosition = new Vector3(lastXPosition, height, 0);


        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}

