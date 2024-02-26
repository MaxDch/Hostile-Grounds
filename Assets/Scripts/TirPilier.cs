using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirPilier : MonoBehaviour
{
    public float Timer;
    public GameObject Projectile;
    public GameObject ZoneTir;
    public GameObject Player;
    public GameObject ZoneAttaque;
    
    void Start()
    {
        Timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer = Timer + Time.deltaTime;
        if (Timer > 2.0)
        {
            GameObject BouletPilier = Instantiate(Projectile, ZoneTir.transform.position, Quaternion.identity);
            BouletPilier.GetComponent<Rigidbody>().AddForce(ZoneTir.transform.forward * 15.0f, ForceMode.Impulse);
            Timer = 0;

        }
    }
    

}
