using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Vector3 impulseRandomSetting;
    public CinemachineImpulseSource cinemachineImpulseSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Shake();

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ShakeRandom();
        }
    }

    void Shake() 
    {
        cinemachineImpulseSource.GenerateImpulse();
    }

    void ShakeRandom() 
    { 
        Vector3 impulseVelocity = new Vector3(
            UnityEngine.Random.Range(-impulseRandomSetting.x, impulseRandomSetting.x),
            UnityEngine.Random.Range(-impulseRandomSetting.y, impulseRandomSetting.y),
            UnityEngine.Random.Range(-impulseRandomSetting.z, impulseRandomSetting.z));

        Vector3 adaptedImpulseVelocity = Camera.main.transform.TransformDirection(impulseVelocity);

        cinemachineImpulseSource.GenerateImpulse(adaptedImpulseVelocity);
    }
}
