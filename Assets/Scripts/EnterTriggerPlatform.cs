using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTriggerPlatform : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject TriggerSign;
    public GameObject PlatformSign;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        TriggerSign.SetActive(true);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        { 
            PlatformSign.SetActive(true);
            movingPlatform.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlatformSign.SetActive(false);
    }
}
