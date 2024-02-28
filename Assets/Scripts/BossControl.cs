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
        AttackZone = 30.0f;
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
        currentDistance = Vector3.Distance(Boss.transform.position, Player.transform.position);
        Timer = Timer + Time.deltaTime;
        int[] StockAmmos = new int[10];

        if (currentDistance <= AttackZone)
        {

            if (Timer >= 2.0f)
            {

                GameObject BouletBoss = Instantiate(Projectile, ZoneEnvoiProjectile.transform.position, Quaternion.identity);
                BouletBoss.GetComponent<Rigidbody>().AddForce(ZoneEnvoiProjectile.transform.forward * 5.0f, ForceMode.Impulse);
                ZoneEnvoiProjectile.transform.LookAt(Player.transform.position + Vector3.up * 2.0f);
                foreach (int i in StockAmmos)
                { StockAmmos[i] = i - 1; }
                
                Timer = 0;


            }


        }
    }



}
