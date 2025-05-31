using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public Button restartButton;
    public Button menuButton;
    public Button nextLevelButton;

    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (menuButton != null)
            menuButton.onClick.AddListener(BackToMainMenu);

        //if (nextLevelButton != null)
        //    nextLevelButton.onClick.AddListener(LoadNextLevel);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Fonksiyon on");
        if (isGameOver) return;
        isGameOver = true;

        if (ScoreManager.instance != null)
            ScoreManager.instance.FinalizeScore();

        int currentLevel = SaveManager.GetCurrentLevel();
        SaveManager.IncrementFailCount(currentLevel);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (finalScoreText != null && ScoreManager.instance != null)
                finalScoreText.text = "Score: " + ScoreManager.instance.currentScore;
        }

        Time.timeScale = 0f;

        int finalScore = ScoreManager.instance.currentScore;
        int savedHighScore = PlayerPrefs.GetInt("HighestScore", 0);
        if (finalScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighestScore", finalScore);
        }

        int total = PlayerPrefs.GetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TotalScore", total + finalScore);
        int lost = PlayerPrefs.GetInt("GamesLost", 0);
        PlayerPrefs.SetInt("GamesLost", lost + 1);
        PlayerPrefs.SetString("LastPlayed", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        PlayerPrefs.Save();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //public void LoadNextLevel()
    //{
    //    int nextLevel = SaveManager.GetCurrentLevel() + 1;
    //    SaveManager.SetCurrentLevel(nextLevel);
    //    SceneManager.LoadScene("Level" + nextLevel);
    //}
}
