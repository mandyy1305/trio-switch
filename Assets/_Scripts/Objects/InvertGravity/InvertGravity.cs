using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    private static bool invertGravity;
    public static event Action<bool> OnInvert;
        
    private void Start()
    {
        invertGravity = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        invertGravity = !invertGravity;
        OnInvert?.Invoke(invertGravity);
    }
}
