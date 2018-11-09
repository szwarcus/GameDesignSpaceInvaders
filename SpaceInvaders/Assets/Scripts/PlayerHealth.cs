using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float health = 3;
    public Text livesTextBox;
    // Update is called once per frame
    void Update()
    {
        string livesText = "LIVES: ";
        for(int i=0;i< health; i++)
        {
            livesText += "♥";
        }
        livesTextBox.text = livesText;
        if (health <= 0)
        {
            
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
    }
}
