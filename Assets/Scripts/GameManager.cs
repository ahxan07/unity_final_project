using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public GameObject startPanel;
    public bool gameStarted = false;
    public static bool restartFromGame = false;
    public AudioSource audioSource;
    public AudioClip playerDeathClip;

    void Start()
    {
        UpdateScoreText(); // Initialize score display
        if (restartFromGame)
        {
            StartGame(); // Skip start panel if restarting
        }
        else
        {
            Time.timeScale = 0f; // Pause until start
            if (startPanel != null)
                startPanel.SetActive(true);
        }
    }
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Cursor.lockState = CursorLockMode.None;
        StopAllCoroutines();
        StartCoroutine(HandleGameOverSequence());
    }
    private IEnumerator HandleGameOverSequence()
    {
        // Play death sound if available
        if (audioSource != null && playerDeathClip != null)
        {
            audioSource.PlayOneShot(playerDeathClip);
            yield return new WaitForSeconds(playerDeathClip.length);
        }

        // Show Game Over UI
        if (gameOverText != null) gameOverText.gameObject.SetActive(true);
        if (restartButton != null) restartButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        if (startPanel != null)
            startPanel.SetActive(false);

        gameStarted = true;
        Cursor.lockState = CursorLockMode.Locked;
        // Resume the game
        Time.timeScale = 1f;
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
        restartFromGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
