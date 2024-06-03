using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crate : MonoBehaviour, IBurnable
{
    public bool isBurning;
    private bool gettingShot = false;

    [SerializeField] private float totalTime = 2.0f;
    [SerializeField] private float currentTime;
    private float lastCollisionTime = 0f;
    private float collisionDuration = 0.1f;
    private void Start()
    {
        currentTime = totalTime;
        isBurning = false;

        InvertGravity.OnInvert += InvertGravity_OnInvert;
    }
    private void OnDestroy()
    {
        InvertGravity.OnInvert -= InvertGravity_OnInvert;
    }

    private void InvertGravity_OnInvert(bool obj)
    {
        GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
        transform.Rotate(0, 0, 180);
    }

    private void Update()
    {
        gettingShot = Time.time - lastCollisionTime < collisionDuration;

        if (!isBurning && gettingShot)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                isBurning = true;
                ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
                var em = ps.emission;
                em.enabled = true;
                ps.Play();
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        lastCollisionTime = Time.time;
    }
}
