using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private const int POINTS_TO_UPDATE = 100;

    private Text scoreText;
    private static int updatesCounter = 0;

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
        var updates = Convert.ToInt32(playerScore / POINTS_TO_UPDATE);
        if (updates != updatesCounter)
        {
            PlayerController.UpdateFireRate(updates);
            updatesCounter = updates;
        }

        string newPlayerScore= playerScore.ToString().PadLeft(playerScore.ToString().Length + 4, '0');

        scoreText.text = "SCORE:\n" + newPlayerScore;
        
	}
}
