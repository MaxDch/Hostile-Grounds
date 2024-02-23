using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque_Ctrl : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject EndPoint;
    public AnimationCurve curve;
    public bool isreverse=false;

    public float timer;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isreverse)
        {
            timer-= Time.fixedDeltaTime;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
        
        if (timer > curve.keys[curve.length-1].time)
        {
            isreverse = true;

        }
        else if (timer < 0)
        {
            isreverse=false;
        }
        float curvevalue = curve.Evaluate(timer);
        Vector3 position = Vector3.Lerp(startPoint.transform.position, EndPoint.transform.position, curvevalue);
        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null, true);
        }
    }
}
