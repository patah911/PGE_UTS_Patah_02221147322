using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const int NUM_LEVELS = 2;

    public ballcontroller ballcontroller { get; private set; }
    public paddlecontroller paddlecontroller { get; private set; }
    public bata[] bata { get; private set; }

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textlives;
    public TextMeshProUGUI textMessageBox;


    public int level = 1;
    public int lives = 3;

    public string gameOverScene = "GameOver";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        GameData.score = 0;
        lives = 3;

        textlives.text = "Lives: " + lives;
        textScore.text = "Score: " + GameData.score;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        if (level < NUM_LEVELS)
        {
            return;
        }

        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ballcontroller = FindObjectOfType<ballcontroller>();
        paddlecontroller = FindObjectOfType<paddlecontroller>();
        bata = FindObjectsOfType<bata>();
    }

    public void Miss()
    {
        lives--;

        textlives.text = "lives: " + lives;

        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    private void ResetLevel()
    {
        ballcontroller.Resetballcontroller();
        paddlecontroller.ResetPaddle();

    }

    private void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);

    }

    public void Hit(bata bata)
    {
        GameData.score += bata.points;

        textScore.text = "Score: " + GameData.score;

        if (Cleared())
        {
            LoadLevel(level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < bata.Length; i++)
        {
            if (bata[i].gameObject.activeInHierarchy && !bata[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }
}

