using UnityEngine;
using TMPro;
using System.Collections.Generic;

using System.Threading;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public int lives = 3;
    private GameObject currentBall;
    public GameObject gameOverUI;
    public GameObject winUI;
    public int score = 0;
    public int currentLevel = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI livesText;
    public LevelGenerator levelGenerator;
    public List<Block> blocks = new List<Block>();
    public Barrier barrier;  

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("Game started. Initializing...");
        SpawnBall();
        UpdateScoreText();
        UpdateLevelText();
        UpdateLivesText();
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();
        Debug.Log("Life lost. Remaining lives: " + lives);

        if (lives > 0)
        {
            Debug.Log("Spawning a new ball...");
            Invoke("SpawnBall", 1f);
        }
        else
        {
            GameOver();
        }
    }

    public void SpawnBall()
    {
        if (currentBall != null) return;

        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("New ball spawned.");
    }

    public void DestroyBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall);
            currentBall = null;
            Debug.Log("Ball destroyed.");
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        DestroyBall();
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        Debug.Log("Victory! Player has won the game!");
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        Debug.Log("Score added: " + points + ". Total score: " + score);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Score updated: " + score);
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel;
        Debug.Log("Level updated: " + currentLevel);
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
        Debug.Log("Lives updated: " + lives);
    }

    public void RemoveBlock(Block block)
    {
        blocks.Remove(block);
        if (blocks.Count == 0)
        {
            WinGame();
        }
    }

    public void ActivateBarrier()
    {
        barrier.Activate();
        Debug.Log("Barrier activated!");
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        winUI.SetActive(false);
        currentLevel++;
        UpdateLevelText();
        levelGenerator.GenerateLevel();
        Debug.Log("Next level: " + currentLevel + ". Generating new level...");
    }
}
