using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour, IBurnable
{
    public float speed = 5f;

    private float totalTime = 0.3f;
    [SerializeField] private float currentTime;
    private float lastCollisionTime = 0f;
    private float collisionDuration = 0.1f;

    public bool isBurning { get; set; }

    void Start()
    {
        currentTime = totalTime;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
    }

    void Update()
    {
        isBurning = Time.time - lastCollisionTime < collisionDuration;

        if (isBurning)
        {
            currentTime -= Time.deltaTime;
            
            if (currentTime < 0)
            {
                isBurning = false;
                MeltIce();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Respawn>().RespawnPlayer();
        }
        Destroy(gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        lastCollisionTime = Time.time;
    }
    public void MeltIce()
    {
        Destroy(gameObject);
    }
}
