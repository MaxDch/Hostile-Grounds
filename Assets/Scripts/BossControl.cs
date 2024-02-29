using System;
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

    public GameObject bossCamera;

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
        
        int[] StockAmmos = new int[10];

        if (currentDistance <= AttackZone)
        {
            Timer = Timer + Time.deltaTime;

            if (Timer >= 2.0f)
            {

                GameObject BouletBoss = Instantiate(Projectile, ZoneEnvoiProjectile.transform.position, Quaternion.identity);
                BouletBoss.GetComponent<Rigidbody>().AddForce(ZoneEnvoiProjectile.transform.forward * 10.0f, ForceMode.Force);
                ZoneEnvoiProjectile.transform.LookAt(Player.transform);
                foreach (int i in StockAmmos)
                { StockAmmos[i] = i - 1; }
                
                Timer = 0;


            }


        }
    }

    internal void SwapBossCameraActivation(bool b)
    {
        bossCamera.SetActive(b);
    }
}
