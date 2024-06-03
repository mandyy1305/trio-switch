using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WalkthroughGround : MonoBehaviour
{
    //Not fully updated

    private bool layerSwitch = true;
    [SerializeField] private int colliderCount = 0;

    float totalTime = 0.05f;
    [SerializeField] private float currentTime;
    public bool isCountingDown = false;

    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        if(isCountingDown)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                isCountingDown = false;
                currentTime = totalTime;
            }
        }

        if (Input.GetMouseButtonDown(0) && !isCountingDown)
        {
            isCountingDown = true;

            if(colliderCount == 0)
            {
                if (layerSwitch)
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                } 
            }
                layerSwitch = !layerSwitch;
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Crate"))
            colliderCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Crate"))
            colliderCount--;
        
        if (colliderCount == 0)
        {
            if (!layerSwitch)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

}
