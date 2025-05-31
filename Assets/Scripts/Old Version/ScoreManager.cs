using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    public int currentScore = 0;
    public TMP_Text scoreText;
    public Collider pointCheckCollider;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();

        if (pointCheckCollider != null)
        {
            pointCheckCollider.gameObject.AddComponent<PointTriggerHelper>().Initialize(this);
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }

    public void FinalizeScore()
    {

        GameManager.instance.GameOver();
    }

    private class PointTriggerHelper : MonoBehaviour
    {
        private ScoreManager manager;

        public void Initialize(ScoreManager mgr)
        {
            manager = mgr;
        }

        private void OnTriggerEnter(Collider pointCheckCollider)
        {
            if (pointCheckCollider.CompareTag("Obstacle"))
            {
                manager.AddScore(10);
            }
        }
    }
}
