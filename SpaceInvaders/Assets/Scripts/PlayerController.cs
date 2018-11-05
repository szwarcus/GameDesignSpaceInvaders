using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    private float nextFire;
    private Rigidbody2D rigid;

    public float speed;
    public float maxBound, minBound;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

       
	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound)
        {
            h = 0;
            rigid.velocity *= -1;
            return;
        }
        else if (player.position.x > maxBound)
        {
            h = 0;
            rigid.velocity *= -1;
            return;
        }
        float fHorizontalVelocity = rigid.velocity.x;

        fHorizontalVelocity += h;
        if(Mathf.Abs(h)<0.01f)
            fHorizontalVelocity *= Mathf.Pow(1f - 0.00001f, Time.deltaTime * 10f);
        else if (Mathf.Sign(h) !=Mathf.Sign(fHorizontalVelocity))
                fHorizontalVelocity *= Mathf.Pow(1f - 0.009f, Time.deltaTime * 10f);
        else
            fHorizontalVelocity *= Mathf.Pow(1f - 0.3f, Time.deltaTime * 10f);
        rigid.velocity = new Vector2(fHorizontalVelocity, rigid.velocity.y);
        //player.position += Vector3.right * h * speed;
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
