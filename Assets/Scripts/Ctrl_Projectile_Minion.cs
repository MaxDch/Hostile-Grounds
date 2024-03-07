using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Projectile_Minion : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Pompe_Boss" ) 
        { 
            Destroy(gameObject);
        
        
        }

        if(collision.collider.tag == "Ground") 
        {
            Destroy(gameObject);
        
        }
        if (collision.collider.tag == "BOSS")
        {
            Destroy(gameObject);

        }
        if (collision.collider.tag == "WALL")
        {
            Destroy(gameObject);

        }
    }
}
