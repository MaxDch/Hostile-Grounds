using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegePilier2_Attaque_Zone_Continue : MonoBehaviour
{
    
    public GameObject AttackItem;
    public GameObject AttackZone;
    GameObject Player;
    

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        Instantiate(AttackItem, AttackZone.transform.position, Quaternion.identity);
        Destroy(gameObject, 2.0f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("player"))
    //    {
            
    //    }
    //}

}
