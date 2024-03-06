using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Projectile_Minion : MonoBehaviour
{
    // Start is called before the first frame update
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
    }
}
