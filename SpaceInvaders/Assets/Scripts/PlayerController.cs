using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MIN_FIRE_RATE = 0.1F;

    private Transform player;
    private float nextFire;
    private Rigidbody2D rigid;

    private static float FireRate = 0.5f;

    public float speed;
    public float maxBound, minBound;
    public GameObject shot;
    public Transform shotSpawn;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
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
        if (Mathf.Abs(h) < 0.01f)
            fHorizontalVelocity *= Mathf.Pow(1f - 0.2f, Time.deltaTime * 10f);
        else if (Mathf.Sign(h) != Mathf.Sign(fHorizontalVelocity))
            fHorizontalVelocity *= Mathf.Pow(1f - 0.009f, Time.deltaTime * 10f);
        else
            fHorizontalVelocity *= Mathf.Pow(1f - 0.4f, Time.deltaTime * 10f);
        rigid.velocity = new Vector2(fHorizontalVelocity, rigid.velocity.y);
        //player.position += Vector3.right * h * speed;
    }
    
    public static void UpdateFireRate(int updates)
    {
        var result = FireRate - (0.001f * updates);

        FireRate = result <= MIN_FIRE_RATE ? MIN_FIRE_RATE : result;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}