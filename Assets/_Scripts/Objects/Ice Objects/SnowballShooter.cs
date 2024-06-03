using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowballShooter : MonoBehaviour
{
    public GameObject snowball;
    public Transform firepoint;
    void Start()
    {
        StartCoroutine(DelayedSpawn());
    }
    private IEnumerator DelayedSpawn()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }

    void Shoot()
    {
        Instantiate(snowball, firepoint.position, transform.rotation, gameObject.transform);
    }
}
