using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;  // Referencia al componente Text donde se mostrará la puntuación

    void Start()
    {
        // Asegúrate de que el GameManager esté accesible
        int score = Mathf.FloorToInt(PlayerPrefs.GetFloat("PlayerScore", 0f));  // Convierte el puntaje a un número entero
        scoreText.text = "Puntaje: " + score.ToString();  // Muestra el puntaje como entero
    }
}

