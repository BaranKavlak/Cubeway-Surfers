using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text gamesWonText;
    public TMP_Text gamesLostText;
    public TMP_Text highestScoreText;
    public TMP_Text lastPlayedText;
    public Button backButton;
    public GameObject statisticsPanel;
    public GameObject mainMenuPanel;

    void Start()
    {
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        int gamesWon = PlayerPrefs.GetInt("GamesWon", 0);
        int gamesLost = PlayerPrefs.GetInt("GamesLost", 0);
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        string lastPlayed = PlayerPrefs.GetString("LastPlayed", "Never");

        gamesWonText.text = "Games Won: " + gamesWon;
        gamesLostText.text = "Games Lost: " + gamesLost;
        highestScoreText.text = "Highest Score: " + highestScore;
        lastPlayedText.text = "Last Played: " + lastPlayed;
    }

    public void QuitToMainMenu(GameObject statisticsPanel, GameObject mainMenuPanel)
    {
        statisticsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

