using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Pompes : MonoBehaviour
{
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int Damage)
    {
        Health -= Damage;

        if (Health < 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Projectile_Minion")
        {
            TakeDamage(10);
        }
    }
}
