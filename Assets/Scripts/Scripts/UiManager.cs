using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;

    public static UiManager Instance // kalıptır ezberle
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }
    public Image SplashScreen;

    private void Start()
    {
        StartCoroutine(AcilisSekansi());
    }
    IEnumerator  AcilisSekansi()
    {
        float speed = 0.005f;
       while (true)
        {
            yield return null;
            float new_a_value = SplashScreen.color.a * speed;
            SplashScreen.color = new Color(SplashScreen.color.r, SplashScreen.color.g, SplashScreen.color.b);

            if(SplashScreen.color.a >= 0.99) 
            {

            }
        }


    }
}
