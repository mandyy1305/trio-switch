using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField]Collider2D collider1;
    [SerializeField]Collider2D collider2;
    void Start()
    {
        collider1 = GetComponent<Collider2D>();
        collider2 = transform.parent.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(collider1, collider2, true);
    }
}
