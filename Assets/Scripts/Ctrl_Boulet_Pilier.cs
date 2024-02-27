using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl_Boulet_Pilier : MonoBehaviour
{
    public float Timer;

    public GameObject Boulet;
    public GameObject FxBoulet;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer = Timer + Time.deltaTime;
        if(Timer > 5.0f) 
        { 
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        Instantiate(FxBoulet, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
