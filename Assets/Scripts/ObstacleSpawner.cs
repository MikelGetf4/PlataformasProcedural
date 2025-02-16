using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab del cuadrado rojo
    public Transform player;  // Para hacer un seguimiento de la posici�n del jugador
    public float spawnDistance = 10f;  // Distancia a la que generamos un nuevo obst�culo
    public float minGap = 3f;  // M�nimo de distancia entre obst�culos
    public float maxGap = 7f;  // M�ximo de distancia entre obst�culos
    public float minHeight = 2f;  // Altura m�nima en la que aparecer�n los obst�culos
    public float maxHeight = 5f;  // Altura m�xima en la que aparecer�n los obst�culos

    private float lastXPosition;

    void Start()
    {
        lastXPosition = player.position.x;
        SpawnObstacle();  // Generamos el primer obst�culo
    }

    void Update()
    {
        // Si el jugador avanza demasiado, generamos un nuevo obst�culo
        if (player.position.x + spawnDistance > lastXPosition)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        float gap = Random.Range(minGap, maxGap);
        lastXPosition += gap;

        // Generamos una altura aleatoria para el obst�culo
        float height = Random.Range(minHeight, maxHeight);

        // Creamos la posici�n del obst�culo
        Vector3 spawnPosition = new Vector3(lastXPosition, height, 0);

        // Instanciamos el obst�culo
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}

