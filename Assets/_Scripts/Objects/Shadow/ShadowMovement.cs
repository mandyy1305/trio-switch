using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private ScriptableStats _stats;
    float inputHorizontal;
    private Vector2 _frameVelocity;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gathering input
        inputHorizontal = Input.GetAxisRaw("Horizontal");

    }
    private void FixedUpdate()
    {
        HandleDirection();
        ApplyMovement();
    }
    private void HandleDirection()
    {
        if (inputHorizontal == 0)
        {
            var deceleration = _stats.GroundDeceleration;
            _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, inputHorizontal * _stats.MaxSpeed, _stats.Acceleration * Time.fixedDeltaTime);
        }
    }
    private void ApplyMovement()
    {
        rb.velocity =_frameVelocity;
    }

}
