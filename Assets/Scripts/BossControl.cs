using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    bool IsPlayerInRange;
    public GameObject Projectile;
    GameObject Player;
    public GameObject Boss;
    public float Timer;
    public GameObject ZoneEnvoiProjectile;
    UIManager uIManager;

    float currentDistance;
    float AttackZone;
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        AttackZone = 50.0f;
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
        currentDistance = Vector3.Distance (Boss.transform.position, Player.transform.position);
        Timer = Timer + Time.deltaTime;
        int[] StockAmmos = new int[10];
        
        if(currentDistance <= AttackZone) 
        {
            
            if (Timer >= 10.0f) 
            {
                
                GameObject BouletPilier = Instantiate(Projectile, ZoneEnvoiProjectile.transform.position, Quaternion.identity);
                foreach (int i in StockAmmos)
                { StockAmmos[i] = i - 1; }
                Timer = 0;


            }
            

        }
    }
    


}
