using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        UpdateScoreText(); // Initialize score display
    }
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Debug.Log("Game Over: Player died");
        Cursor.lockState = CursorLockMode.None;
        StopAllCoroutines(); // freeze game
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Kills: " + score;
        }
    }

    public void RestartGame()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
