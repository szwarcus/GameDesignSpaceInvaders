using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    private int bulletScore = 10;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        bullet = GetComponent<Transform>();		
	}

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += bulletScore;
        }
        else if (collision.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
