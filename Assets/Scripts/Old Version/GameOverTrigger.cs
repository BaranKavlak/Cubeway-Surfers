using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }
}