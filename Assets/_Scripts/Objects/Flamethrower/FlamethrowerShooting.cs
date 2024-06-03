using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class FlamethrowerShooting : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;
            ps.Play();
        }

        if(Input.GetMouseButtonUp(0))
        {
            ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
            var em = ps.emission;
            em.enabled = false;
            ps.Stop();
        }      
    }
}
    