using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    private const string PlayCountKey = "PlayCount";
    private const string TotalScoreKey = "TotalScore";
    private const string HighScoreKey = "HighScore";

    public static void SaveSettings(int difficulty, int color, int skin, int lightColor, bool shadows)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.SetInt("PlayerColor", color);
        PlayerPrefs.SetInt("PlayerSkin", skin);
        PlayerPrefs.SetInt("LightColor", lightColor);
        PlayerPrefs.SetInt("ShadowsEnabled", shadows ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void UpdateGameStatistics(int gamesWon, int gamesLost, int highestScore, string lastPlayed)
    {
        PlayerPrefs.SetInt("GamesWon", gamesWon);
        PlayerPrefs.SetInt("GamesLost", gamesLost);
        PlayerPrefs.SetInt("HighestScore", highestScore);
        PlayerPrefs.SetString("LastPlayed", lastPlayed);
        PlayerPrefs.Save();
    }

    public static void SetDifficulty(int difficultyIndex)
    {
        PlayerPrefs.SetInt("difficulty", difficultyIndex);
        PlayerPrefs.Save();
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }

    public static void SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt("currentLevel", level);
        PlayerPrefs.Save();
    }

    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("currentLevel", 1);
    }

    public static void SetPlayerSettings(int playerColorIndex, int playerSkinIndex)
    {
        PlayerPrefs.SetInt("playerColor", playerColorIndex);
        PlayerPrefs.SetInt("playerSkin", playerSkinIndex);
        PlayerPrefs.Save();
    }

    public static int GetPlayerColor()
    {
        return PlayerPrefs.GetInt("playerColor", 0);
    }

    public static int GetPlayerSkin()
    {
        return PlayerPrefs.GetInt("playerSkin", 0);
    }

    public static void SetGameSettings(int lightColorIndex, bool shadowsEnabled)
    {
        PlayerPrefs.SetInt("lightColor", lightColorIndex);
        PlayerPrefs.SetInt("shadows", shadowsEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static int GetLightColor()
    {
        return PlayerPrefs.GetInt("lightColor", 0);
    }

    public static bool GetShadowsEnabled()
    {
        return PlayerPrefs.GetInt("shadows", 1) == 1;
    }

    public static void AddCoins(int amount)
    {
        int current = PlayerPrefs.GetInt("coins", 0);
        PlayerPrefs.SetInt("coins", current + amount);
        PlayerPrefs.Save();
    }

    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt("coins", 0);
    }

    public static void IncrementPlayCount(int level)
    {
        string key = $"playCount_level_{level}";
        int count = PlayerPrefs.GetInt(key, 0);
        PlayerPrefs.SetInt(key, count + 1);
        PlayerPrefs.Save();
    }

    public static int GetPlayCount(int level)
    {
        return PlayerPrefs.GetInt($"playCount_level_{level}", 0);
    }

    public static void IncrementFailCount(int level)
    {
        string key = $"failCount_level_{level}";
        int count = PlayerPrefs.GetInt(key, 0);
        PlayerPrefs.SetInt(key, count + 1);
        int totalPlayCount = PlayerPrefs.GetInt(PlayCountKey, 0);
        PlayerPrefs.SetInt(PlayCountKey , totalPlayCount + 1);
        PlayerPrefs.Save();
    }
    public static int GetFailCount(int level)
    {
        return PlayerPrefs.GetInt($"failCount_level_{level}", 0);
    }
    public static void AddToTotalScore(int score)
    {
        int current = PlayerPrefs.GetInt(TotalScoreKey, 0);
        PlayerPrefs.SetInt(TotalScoreKey , current + score);
        PlayerPrefs.Save();
    }
    public static void TrySetHighScore(int score)
    {
        int currentHigh = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(score > currentHigh)
        {
            PlayerPrefs.SetInt(HighScoreKey , score);
            PlayerPrefs.Save();
        }
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}
