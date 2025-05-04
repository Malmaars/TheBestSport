using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreToWin;

    //if the score goes to the negative of scoretowin, the right side wins, and if it goes to the positive of scoretowin, the left side wins
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddScore(bool _left, int points)
    {
        if (_left)
            score += points;
        else 
            score -= points;

        UpdateScoreBoard();
    }

    void UpdateScoreBoard()
    {

    }
}
