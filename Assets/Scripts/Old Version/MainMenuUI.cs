using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button statisticsButton;
    public Button quitButton;


    public GameObject settingsPanel;
    public GameObject statisticsPanel;
    public GameObject mainMenuLevel;
    public GameObject GameName;
    public GameObject CompanyLogo;

    void Start()
    {
        ShowMainMenu();

        playButton.onClick.AddListener(PlayButtonClicked);
        settingsButton.onClick.AddListener(SettingsButtonClicked);
        statisticsButton.onClick.AddListener(StatisticsButtonClicked);
        quitButton.onClick.AddListener(QuitButtonClicked);
    }

    private void ShowMainMenu()
    {
        settingsPanel.SetActive(false);
        statisticsPanel.SetActive(false);
        mainMenuLevel.SetActive(true);
        EnableLogosandButtons();
        
    }
    private void EnableLogosandButtons()
    {
        GameName.SetActive(true);
        CompanyLogo.SetActive(true);
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        statisticsButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void DisableLogosandButtons()
    {
        GameName.SetActive(false);
        CompanyLogo.SetActive(false);
        playButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        statisticsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        
    }

    void PlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    void SettingsButtonClicked()
    {
        Debug.Log("Settings calisii");
        settingsPanel.SetActive(true);
        DisableLogosandButtons();
        
    }


    void StatisticsButtonClicked()
    {
        statisticsPanel.SetActive(true);
        DisableLogosandButtons();
    }
    void QuitButtonClicked()
    {
        Application.Quit();
    }

    



}
