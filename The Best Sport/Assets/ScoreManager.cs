using System.Data;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreToWin;

    //if the score goes to the negative of scoretowin, the right side wins, and if it goes to the positive of scoretowin, the left side wins
    public int score;

    public RectTransform scoreBoardBackground;
    public RectTransform scorePin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddScore(-1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddScore(1);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        
        UpdateScoreBoard();
    }

    void UpdateScoreBoard()
    {
        //place the score counter a given distance to the left or right

        //take the width of the scoreboard and divide it by twice the required score
        float oneStep = (scoreBoardBackground.sizeDelta.x / 2) / scoreToWin;

        scorePin.anchoredPosition = new Vector2(oneStep * score, scorePin.anchoredPosition.y);

    }
}
