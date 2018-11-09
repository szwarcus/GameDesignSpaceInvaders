using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulletController : MonoBehaviour
{

    private Transform bullet;
    public float speed;

    
    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Transform>();
        
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
            Destroy(bullet.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject playerBase = other.gameObject;
            PlayerHealth playerHealth = playerBase.GetComponent<PlayerHealth>();
            PlayerController player = playerBase.GetComponent<PlayerController>();
            playerHealth.health -= 1;
            //StartCoroutine(FlickerFunc(playerBase));
            player.StartCoroutine(FlickerFunc(playerBase));

            Destroy(gameObject);
            //GameOver.isPlayerDead = true;
        }
        else if (other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
    public IEnumerator FlickerFunc(GameObject player)
    {
        for (int i = 0; i < 2; i++)
        {
            player.GetComponent<Renderer>().enabled = false;
            player.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.5F / 2);
            player.GetComponent<Renderer>().enabled = true;
            player.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.5F / 2);
        }
    }
}