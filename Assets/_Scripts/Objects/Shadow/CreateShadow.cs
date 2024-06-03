using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShadow : MonoBehaviour
{
    float input;
    float latestInput = 1.0f;

    [SerializeField] private GameObject raycastPoint;
    [SerializeField] private float laserLength;
    [SerializeField]public GameObject shadow;
    private int shadowCount = 0;
    [SerializeField]public GameObject instantiatedShadow;

    Vector2 right;

    // Start is called before the first frame update
    void Start()
    {
        InvertGravity.OnInvert += InvertGravity_OnInvert;
        raycastPoint = transform.GetChild(1).gameObject;
        right = new Vector2(1, 0);
    }

    private void OnDestroy()
    {
        InvertGravity.OnInvert -= InvertGravity_OnInvert;
    }

    private void InvertGravity_OnInvert(bool obj)
    {
        Vector3 temp = raycastPoint.transform.localPosition;
        temp.x *= -1.0f;
        raycastPoint.transform.localPosition = temp;

        right *= -1;
    }

    // Update is called once per frame
    void Update()
    {

        input = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(input, 0.0f))
        {
            if (!Mathf.Approximately(input, latestInput)) 
            {
                Vector3 temp = raycastPoint.transform.localPosition;
                temp.x *= - 1.0f;
                raycastPoint.transform.localPosition = temp;
            }
            latestInput = input;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = gameObject.transform.position;
            
            if (shadowCount == 0)
            {
                pos.x += latestInput;
                InstantiateShadow(pos);

            }
        }

        if(instantiatedShadow != null && VectorApproximately(instantiatedShadow.transform.position, transform.position))
        {
            Destroy(instantiatedShadow);
            shadowCount--;
        }

    }

    void InstantiateShadow(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.transform.position, right * Mathf.Sign(raycastPoint.transform.localPosition.x), laserLength);

        if (hit.collider != null)
        {
            Debug.Log("No shadow --> Hitting: " + hit.collider.tag);
            return;
        }
        

        instantiatedShadow =  Instantiate(shadow, pos, Quaternion.identity);
        shadowCount++;
    }

    bool VectorApproximately(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Abs(pos1.x - pos2.x) < 0.01f
            && Mathf.Abs(pos1.y - pos2.y) < 0.01f;
    }
}
