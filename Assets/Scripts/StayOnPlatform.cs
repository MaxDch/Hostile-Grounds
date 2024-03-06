using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class StayOnPlatform : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject Trigger;
    
    public GameObject startPoint;
    public GameObject EndPoint;
    public AnimationCurve curve;
    public float timer;
    public bool isreverse = false;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isreverse)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }

        if (timer > curve.keys[curve.length - 1].time)
        {
            isreverse = true;

        }
        else if (timer < 0)
        {
            isreverse = false;
        }
        float curvevalue = curve.Evaluate(timer);
        Vector3 position = Vector3.Lerp(startPoint.transform.position, EndPoint.transform.position, curvevalue);
        transform.position = position;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Trigger.transform.SetParent(movingPlatform.transform);
            other.transform.SetParent(movingPlatform.transform, true);
            
        }
    }
}
