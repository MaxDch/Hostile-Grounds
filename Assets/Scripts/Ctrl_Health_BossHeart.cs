using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Health_BossHeart : MonoBehaviour
{
    public int Health;
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Health = Health - 10;
        }
        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
