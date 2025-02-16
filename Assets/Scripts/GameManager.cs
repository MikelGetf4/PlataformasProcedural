using UnityEngine;
using UnityEngine.UI;  // Necesario para mostrar el puntaje en la UI

public class GameManager : MonoBehaviour
{
    public Text scoreText;  // Referencia al UI Text donde mostrarás el puntaje
    private float score;    // Variable para el puntaje

    public Transform player;  // Para poder seguir la posición del jugador
    private float lastPlayerX;  // Última posición X del jugador

    void Start()
    {
        // Inicializamos el puntaje y la posición del jugador
        score = 0f;
        lastPlayerX = player.position.x;
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
        // El puntaje aumenta por la diferencia en la posición X del jugador
        float distanceTraveled = player.position.x - lastPlayerX;

        // Solo sumamos si el jugador ha avanzado (en positivo)
        if (distanceTraveled > 0)
        {
            score += distanceTraveled;
            lastPlayerX = player.position.x;  // Actualizamos la última posición X
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


}

