using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private const string highScoreTextContent = "Highscore: ";
    private const string highScorePlayerPrefName = "highScore";
    private Text highScoreText;

	void Start ()
    {
        highScoreText = GetComponent<Text>();
        highScoreText.alignment = TextAnchor.MiddleCenter;
        highScoreText.text = highScoreTextContent + PlayerPrefs.GetInt(highScorePlayerPrefName, 0);
    }
	
	void Update ()
    {
		if (GameOver.isPlayerDead)
        {
            try
            {
                var highScore = SetHighScore(Convert.ToInt32(PlayerScore.playerScore));
                highScoreText.text = highScoreTextContent + highScore.ToString();
            }
            catch (Exception ex)
            {
                Debug.Log("GameOver: " + ex.Message);
            }
        }
	}

    // return actual high score
    private int SetHighScore(int playerScore)
    {
        var highScore = PlayerPrefs.GetInt(highScorePlayerPrefName, -1);

        highScore = playerScore < highScore ? highScore : playerScore;

        PlayerPrefs.SetInt(highScorePlayerPrefName, highScore);

        return highScore;
    }
}