using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSurfaces : MonoBehaviour, IBurnable
{
    public bool isBurning;
    //Countdown tiemr
    [SerializeField] float totalTime = 3.0f;
    [SerializeField] private float currentTime;
    private float lastCollisionTime = 0f;
    private float collisionDuration = 0.1f;

    void Start()
    {
        currentTime = totalTime;
        isBurning = false;
    }
    private void Update()
    {
        isBurning = Time.time - lastCollisionTime < collisionDuration;

        if (isBurning)
        {
            currentTime -= Time.deltaTime;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - 0.15f * Time.deltaTime, gameObject.transform.localScale.z);

            if (currentTime < 0)
            {
                isBurning = false;
                MeltIce();
            }
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        lastCollisionTime = Time.time;
    }
    private void MeltIce()
    {
        Destroy(gameObject);
    }
}
