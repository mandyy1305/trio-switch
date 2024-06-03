using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteamTurbines : MonoBehaviour, IBurnable
{
    public bool isBurning;
    public GameObject steamDoor;

    private float lastCollisionTime = 0f;
    private float collisionDuration = 0.2f;

    private void Start()
    {
        isBurning = false;
    }
    private void Update()
    {
        isBurning = Time.time - lastCollisionTime < collisionDuration;


        if (isBurning)
        {

            if (steamDoor.transform.localPosition.x > -1.7f)
                steamDoor.transform.localPosition = new Vector3(steamDoor.transform.localPosition.x - 0.05f, steamDoor.transform.localPosition.y, 0f);
            else
                steamDoor.transform.localPosition = new Vector3(-1.7f, steamDoor.transform.localPosition.y, 0f);
        }
        else
        {
            if (steamDoor.transform.localPosition.x < 0f)
                steamDoor.transform.localPosition = new Vector3(steamDoor.transform.localPosition.x + 0.05f, steamDoor.transform.localPosition.y, 0f);
            else
                steamDoor.transform.localPosition = new Vector3(0f, steamDoor.transform.localPosition.y, 0f);
            
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        lastCollisionTime = Time.time;
    }
}
