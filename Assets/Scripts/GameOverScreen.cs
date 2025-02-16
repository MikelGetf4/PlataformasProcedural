using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;  // Referencia al componente Text donde se mostrar� la puntuaci�n

    void Start()
    {
        // Aseg�rate de que el GameManager est� accesible
        int score = Mathf.FloorToInt(PlayerPrefs.GetFloat("PlayerScore", 0f));  // Convierte el puntaje a un n�mero entero
        scoreText.text = "Puntaje: " + score.ToString();  // Muestra el puntaje como entero
    }
}

