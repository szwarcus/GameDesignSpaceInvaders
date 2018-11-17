using UnityEngine;
using EZCameraShake;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    private int bulletScore = 20;
    public GameObject particleExplosionSystem;
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
            GameObject instantiatedParticleSystem=Instantiate(particleExplosionSystem,transform.position,transform.rotation);
            Destroy(instantiatedParticleSystem, 1f);
            PlayerScore.playerScore += bulletScore;
            
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
        else if (collision.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
