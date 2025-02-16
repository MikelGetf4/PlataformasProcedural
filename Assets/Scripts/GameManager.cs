using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Instancia estática del GameManager

    public Text scoreText;  // Referencia al UI Text donde mostrarás el puntaje
    private float score;    // Variable para el puntaje

    public Transform player;  // Para poder seguir la posición del jugador
    private float lastPlayerX;  // Última posición X del jugador

    void Awake()
    {
        // Asegúrate de que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;  // Asignamos la instancia
            DontDestroyOnLoad(gameObject);  // Opcional: evitar que se destruya entre escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya hay una instancia, destruimos el objeto duplicado
        }
    }

    void Start()
    {
        // Inicializamos el puntaje y la posición del jugador
        score = 0f;
        lastPlayerX = player.position.x;

        // Recuperar el puntaje guardado cuando se carga la escena
        score = PlayerPrefs.GetFloat("PlayerScore", 0f); // Recuperamos el puntaje
    }

    void Update()
    {
        // Sumamos puntos mientras el jugador avanza
        UpdateScore();
        DisplayScore();  // Actualizamos la UI con el puntaje
    }

    // Método para actualizar el puntaje
    void UpdateScore()
    {
        // Verificamos si el jugador no es null antes de acceder a su posición
        if (player != null)
        {
            float distanceTraveled = player.position.x - lastPlayerX;

            // Solo sumamos si el jugador ha avanzado (en positivo)
            if (distanceTraveled > 0)
            {
                score += distanceTraveled;
                lastPlayerX = player.position.x;  // Actualizamos la última posición X
            }
        }
    }

    // Mostrar puntaje en la UI
    void DisplayScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + Mathf.FloorToInt(score).ToString();  // Mostramos el puntaje como número entero
        }
    }

    // Método para guardar la puntuación
    public void SaveScore()
    {
        PlayerPrefs.SetFloat("PlayerScore", score);  // Guardamos el puntaje al finalizar el juego
        PlayerPrefs.Save();  // Aseguramos que los cambios se guarden
    }
}
