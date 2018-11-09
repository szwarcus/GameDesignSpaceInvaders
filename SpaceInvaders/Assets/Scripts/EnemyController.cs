using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    private Transform enemyHolder;
    private GameObject spawnedEnemies;

    public float speed;
    public GameObject shot;
    public Text winText;
    public Text bonusText;
    public float fireRate = 0.997f;
    public GameObject[] thePlatform;
    public float distanceBetween;

    // Use this for initialization
    void Start()
    {
        winText.enabled = false;
        int indexChoosed = Random.Range(0, thePlatform.Length);
        spawnedEnemies=Instantiate(thePlatform[indexChoosed], transform.position, transform.rotation);
        spawnedEnemies.transform.parent = gameObject.transform;
        enemyHolder = spawnedEnemies.GetComponent<Transform>() ;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);

    }


    void MoveEnemy()
    {
        Time.timeScale = 1;
        bonusText.enabled = false;
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -14.5 || enemy.position.x > 14.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.7f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }


            if (enemy.position.y <= -5)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }
        if (enemyHolder.childCount == 0)
        {
            Destroy(spawnedEnemies);
            CancelInvoke();
            transform.position = new Vector3(0f, transform.position.y + distanceBetween, 0f);
            int indexChoosed = Random.Range(0, thePlatform.Length);
            int bonusPoints= Random.Range(1, 10) * 50;
            bonusText.text = "BONUS   " + bonusPoints.ToString()+ "   POINTS";
            
            bonusText.enabled = true;

            PlayerScore.playerScore += bonusPoints;
            Vector2 spawnPosition = new Vector2(0, 9);
            PlayerController.fireRate -= 0.05F;
            spawnedEnemies = Instantiate(thePlatform[indexChoosed], spawnPosition, thePlatform[indexChoosed].transform.rotation);
            spawnedEnemies.transform.parent = gameObject.transform;
            enemyHolder = spawnedEnemies.GetComponent<Transform>();
            Time.timeScale = 0.2F;
            InvokeRepeating("MoveEnemy", 0.1f, 0.3f);

        }

    }
}