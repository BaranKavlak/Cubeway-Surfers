using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    
    public GameObject logo;
    public GameObject background;
    [SerializeField] public float splashDuration = 3f;
    [SerializeField] public float fadeDuration = 2f;

    private void Start()
    {
        StartCoroutine(ShowSplashScreen());
    }

    IEnumerator ShowSplashScreen()
    {
        logo.SetActive(true);
        background.SetActive(true);
        yield return new WaitForSeconds(splashDuration);

        float timer = 0f;
        CanvasGroup logoCanvasGroup = logo.GetComponent<CanvasGroup>();
        CanvasGroup backgroundCanvasGroup = background.GetComponent<CanvasGroup>();

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1,0, timer / fadeDuration);
            logoCanvasGroup.alpha = alpha;
            backgroundCanvasGroup.alpha = alpha;
            yield return null;
        }
        logo.SetActive(false);
        background.SetActive(false);
        LoadMainMenu();
        
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
