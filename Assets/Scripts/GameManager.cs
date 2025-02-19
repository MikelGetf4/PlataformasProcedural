using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  

    public Text scoreText;  
    private float score;    

    public Transform player;  
    private float lastPlayerX;  

    void Awake()
    {
        // Asegúrate de que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;  
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0f;
        lastPlayerX = player.position.x;

        score = PlayerPrefs.GetFloat("PlayerScore", 0f);
    }

    void Update()
    {
        
        UpdateScore();
        DisplayScore();
    }

    void UpdateScore()
    {
        if (player != null)
        {
            float distanceTraveled = player.position.x - lastPlayerX;

            if (distanceTraveled > 0)
            {
                score += distanceTraveled;
                lastPlayerX = player.position.x;
            }
        }
    }

    void DisplayScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetFloat("PlayerScore", score);
        PlayerPrefs.Save();
    }
}
