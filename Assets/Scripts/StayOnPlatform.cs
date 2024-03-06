using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject Trigger;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trigger.transform.SetParent(movingPlatform.transform);
            Player.transform.SetParent(movingPlatform.transform, true);
            movingPlatform.transform.position += movingPlatform.transform.right * Time.deltaTime;
        
        }
    }
}
