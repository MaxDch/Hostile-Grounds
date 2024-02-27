using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    bool IsPlayerInRange;
    public GameObject Projectile;
    GameObject Player;
    public float Timer;
    public GameObject ZoneEnvoiProjectile;
    void Start()
    {
        Timer = 0;
        foreach (var charController in FindObjectsOfType<CharacterController>())
        {
            if (charController.gameObject.CompareTag("Player"))
            {
                Player = charController.gameObject;
                break;
            }

        }
    }
    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Timer = Timer + Time.deltaTime;
        if(Timer > 5.0f && IsPlayerInRange)
        {

            GameObject BouletPilier = Instantiate(Projectile, ZoneEnvoiProjectile.transform.position, Quaternion.identity);
            ZoneEnvoiProjectile.transform.LookAt(Player.transform.position + Vector3.up * 1.5f);
            BouletPilier.GetComponent<Rigidbody>().AddForce(ZoneEnvoiProjectile.transform.forward * 0.5f, ForceMode.VelocityChange);
            Timer = 0;

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        { 
            IsPlayerInRange = true;
            Timer = 0;

        }
    }
}
