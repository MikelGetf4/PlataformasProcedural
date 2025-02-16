using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float spawnDistance = 10f;
    public float despawnDistance = 15f;
    public float minGap = 2f;
    public float maxGap = 5f;

    // Variables para controlar el ancho y las alturas de las plataformas
    public float minWidth = 1f;
    public float maxWidth = 3f;
    public float minHeight = -3f;  // Minima altura para la plataforma
    public float maxHeight = -5f;  // Maxima altura para la plataforma

    public GameObject movingPlatformPrefab;  // Prefab de plataformas móviles

    private float lastXPosition;

    void Start()
    {
        lastXPosition = player.position.x;
        SpawnPlatform(); // Generamos la primera plataforma
    }

    void Update()
    {
        // Si el jugador avanza demasiado, generamos una nueva plataforma
        if (player.position.x + spawnDistance > lastXPosition)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float gap = Random.Range(minGap, maxGap);
        lastXPosition += gap;

        // Escala aleatoria para el ancho de la plataforma
        float width = Random.Range(minWidth, maxWidth);

        // Elección aleatoria de plataforma especial (móvil o normal)
        int platformType = Random.Range(0, 2); // 0: normal, 1: móvil
        GameObject platformPrefabToSpawn = platformPrefab;  // Por defecto es la plataforma normal
        if (platformType == 1)
        {
            platformPrefabToSpawn = movingPlatformPrefab;  // Si es móvil, usamos el prefab de plataformas móviles
        }

        // Generamos la altura de la plataforma de manera aleatoria dentro del rango especificado
        float height = Random.Range(minHeight, maxHeight);

        // Creamos la posición de la plataforma
        Vector3 spawnPosition = new Vector3(lastXPosition, height, 0);

        // Instanciamos la plataforma
        GameObject platform = Instantiate(platformPrefabToSpawn, spawnPosition, Quaternion.identity);

        // Cambiamos el ancho de la plataforma
        platform.transform.localScale = new Vector3(width, platform.transform.localScale.y, platform.transform.localScale.z);

        // Si la plataforma es móvil, le damos movimiento
        if (platformType == 1)
        {
            platform.AddComponent<MovingPlatform>();  // Asume que hay un script MovingPlatform que hace mover la plataforma
        }

        // Agregamos el despawn para que la plataforma sea destruida al salir de la vista
        platform.AddComponent<PlatformDespawner>().player = player;
    }
}

public class PlatformDespawner : MonoBehaviour
{
    public Transform player;
    public float despawnDistance = 15f;

    void Update()
    {
        // Destruimos la plataforma si está demasiado lejos del jugador
        if (player != null && transform.position.x < player.position.x - despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}

// Ejemplo de plataforma móvil
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
