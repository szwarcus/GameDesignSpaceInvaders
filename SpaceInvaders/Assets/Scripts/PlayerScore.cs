using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Text scoreText;

    public static float playerScore = 0;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        scoreText.alignment = TextAnchor.UpperCenter;
    }
	
	// Update is called once per frame
	void Update ()
    {
        string newPlayerScore= playerScore.ToString().PadLeft(playerScore.ToString().Length + 4, '0');
        

        scoreText.text = "SCORE:\n" + newPlayerScore;
        
	}
}
