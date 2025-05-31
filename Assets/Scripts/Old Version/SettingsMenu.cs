using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown;
    public TMP_Dropdown colorDropdown;
    public TMP_Dropdown skinDropdown;
    public TMP_Dropdown lightColorDropdown;
    public Toggle shadowsToggle;
    public Light sceneLight;

    public Material classicMat;
    public Material metalMat;
    public Material ShiningMat;
    public Renderer playerRenderer;

    public Button applyButton;
    public Button cancelButton;
    public Button defaultButton;
    public Button backButton;

    public GameObject settingsPanel;
    public GameObject mainMenuPanel;

    private void Start()
    {
        LoadInitialSettings();

        skinDropdown.onValueChanged.AddListener(delegate { UpdatePlayerMaterial(); });
        colorDropdown.onValueChanged.AddListener(delegate { UpdatePlayerColor(); });
        lightColorDropdown.onValueChanged.AddListener(delegate { UpdateLightColor(); });

        applyButton.onClick.AddListener(ApplySettings);
        cancelButton.onClick.AddListener(CancelSettings);
        defaultButton.onClick.AddListener(SetDefaultSettings);
        backButton.onClick.AddListener(() => QuitToMainMenu(settingsPanel, mainMenuPanel));
    }

    private void LoadInitialSettings()
    {
        difficultyDropdown.value = SaveManager.GetDifficulty();
        colorDropdown.value = SaveManager.GetPlayerColor();
        skinDropdown.value = SaveManager.GetPlayerSkin();
        lightColorDropdown.value = SaveManager.GetLightColor();
        shadowsToggle.isOn = SaveManager.GetShadowsEnabled();

        UpdatePlayerMaterial();
        UpdatePlayerColor();
    }

    public void ApplySettings()
    {
        SaveManager.SetDifficulty(difficultyDropdown.value);
        SaveManager.SetPlayerSettings(colorDropdown.value, skinDropdown.value);
        SaveManager.SetGameSettings(lightColorDropdown.value, shadowsToggle.isOn);

        UpdatePlayerMaterial();
        UpdatePlayerColor();
        UpdateLightColor();
        LoadInitialSettings();
    }

    public void CancelSettings()
    {
        LoadInitialSettings();
    }

    public void SetDefaultSettings()
    {
        difficultyDropdown.value = 1;
        colorDropdown.value = 0;
        skinDropdown.value = 0;
        lightColorDropdown.value = 0;
        shadowsToggle.isOn = true;

        UpdatePlayerMaterial();
        UpdatePlayerColor();
    }

    private void UpdatePlayerMaterial()
    {
        if (playerRenderer == null) return;

        switch (skinDropdown.value)
        {
            case 0:
                playerRenderer.material = classicMat;
                break;
            case 1:
                playerRenderer.material = metalMat;
                break;
            case 2:
                playerRenderer.material = ShiningMat;
                break;
            default:
                playerRenderer.material = classicMat;
                break;
        }
        UpdatePlayerColor();
    }

    private void UpdateLightColor()
    {
        if (sceneLight == null) return;

        switch (lightColorDropdown.value)
        {
            case 0:
                sceneLight.color = Color.white;
                break;
            case 1:
                sceneLight.color = Color.yellow;
                break;
            case 2:
                sceneLight.color = new Color(1f, 0.64f, 0f); // Turuncumsu
                break;
            default:
                sceneLight.color = Color.white;
                break;
        }
    }


    private void UpdatePlayerColor()
    {
        if (playerRenderer == null) return;

        switch (colorDropdown.value)
        {
            case 0:
                playerRenderer.material.color = Color.red;
                break;
            case 1:
                playerRenderer.material.color = Color.blue;
                break;
            case 2:
                playerRenderer.material.color = Color.green;
                break;
            default:
                playerRenderer.material.color = Color.white;
                break;
        }
    }

    public void QuitToMainMenu(GameObject settingsPanel, GameObject mainMenuPanel)
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
