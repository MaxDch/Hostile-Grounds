using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerPlatform : MonoBehaviour
{
    public GameObject movingPlatform;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player") 
        {
            other.gameObject.transform.SetParent(null, true);
            movingPlatform.SetActive(false);
        }
        
    }
}
