using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    private float nextFire;

    public float speed;
    public float maxBound, minBound;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
       
	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Transform>();
	}
	
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound && h < 0)
        {
            h = 0;
        }
        else if (player.position.x > maxBound && h > 0)
        {
            h = 0;
        }

        player.position += Vector3.right * h * speed;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
