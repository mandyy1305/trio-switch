using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalPositionSwitch : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] public static Dictionary<GameObject, bool> isPortaling;

    private void Start()
    {
        isPortaling = new Dictionary<GameObject, bool>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPortaling.ContainsKey(collision.gameObject)) isPortaling.Add(collision.gameObject, false);

        if (!isPortaling[collision.gameObject])
        {
            isPortaling[collision.gameObject] = true;
            StartCoroutine(delay(collision.gameObject));
            collision.transform.position = portal.transform.position;
        }
    }   
    
    IEnumerator delay(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        isPortaling[go] = false;
        
    }
    
}
