using UnityEngine;

public class Goal : MonoBehaviour
{
    public ScoreManager scoreManager;

    public int scoreToAdd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //score
            scoreManager.AddScore(scoreToAdd);
            //then remove the ball
            GameManager.instance.DeSpawnCurrentBall();
        }
    }
}
