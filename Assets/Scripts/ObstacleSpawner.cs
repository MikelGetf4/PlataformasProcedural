using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab del cuadrado rojo
    public Transform player;  // Para hacer un seguimiento de la posición del jugador
    public float spawnDistance = 10f;  // Distancia a la que generamos un nuevo obstáculo
    public float minGap = 3f;  // Mínimo de distancia entre obstáculos
    public float maxGap = 7f;  // Máximo de distancia entre obstáculos
    public float minHeight = 2f;  // Altura mínima en la que aparecerán los obstáculos
    public float maxHeight = 5f;  // Altura máxima en la que aparecerán los obstáculos

    private float lastXPosition;

    void Start()
    {
        lastXPosition = player.position.x;
        SpawnObstacle();  // Generamos el primer obstáculo
    }

    void Update()
    {
        // Si el jugador avanza demasiado, generamos un nuevo obstáculo
        if (player.position.x + spawnDistance > lastXPosition)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        float gap = Random.Range(minGap, maxGap);
        lastXPosition += gap;

        // Generamos una altura aleatoria para el obstáculo
        float height = Random.Range(minHeight, maxHeight);

        // Creamos la posición del obstáculo
        Vector3 spawnPosition = new Vector3(lastXPosition, height, 0);

        // Instanciamos el obstáculo
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}

