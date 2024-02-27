using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Projectile_Boss : MonoBehaviour
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
        if (Timer > 60.0f)
        {
            Destroy(gameObject);
            Timer= 0;
        }
    }
    public void Explode()
    {
        Instantiate(FxBoulet, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

