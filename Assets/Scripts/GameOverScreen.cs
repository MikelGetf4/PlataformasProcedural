using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int score = Mathf.FloorToInt(PlayerPrefs.GetFloat("PlayerScore", 0f));
        scoreText.text = "Puntaje: " + score.ToString();
    }
}

