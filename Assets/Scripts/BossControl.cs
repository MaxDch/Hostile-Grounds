using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    bool IsPlayerInRange;
    public GameObject Projectile;
    public GameObject bossCamera;
    GameObject Player;
    public GameObject Boss;
    public float Timer;
    public GameObject ZoneEnvoiProjectile;
    UIManager uIManager;

    public Health[] _pumps;
    public GameObject[] _objectToHideByPumpDeath;

    List<GameObject> StockAmmos = new List<GameObject>();

    float currentDistance;
    public float AttackZone;
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        AttackZone = 20.0f;
        Timer = 0;
        foreach (var charController in FindObjectsOfType<CharacterController>())
        {
            if (charController.gameObject.CompareTag("Player"))
            {
                Player = charController.gameObject;
                break;
            }

        }

        foreach(Health health in _pumps)
        {
            health._onDeath += OnPumpDeath;
        }
    }
    
    private void FixedUpdate()
    {
        for(int i = StockAmmos.Count - 1; i >= 0; --i)
        {
            if (StockAmmos[i] == null)
            {
                StockAmmos.RemoveAt(i);
            }
        }

        currentDistance = Vector3.Distance(Boss.transform.position, Player.transform.position);

        if (currentDistance <= AttackZone)
        {
            Timer = Timer + Time.deltaTime;

            if (Timer >= 2.0f && StockAmmos.Count < 10)
            {
                GameObject BouletBoss = Instantiate(Projectile, ZoneEnvoiProjectile.transform.position, Quaternion.identity);
                BouletBoss.GetComponent<Projectile>().SetSpawner(gameObject);
                ZoneEnvoiProjectile.transform.LookAt(Player.transform);

                StockAmmos.Add(BouletBoss);
                
                Timer = 0;


            }


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackZone);
    }

    void OnPumpDeath()
    {
        int numberOfPumpDead = 0;

        foreach (Health health in _pumps)
        {
           if(health.IsDead())
            {
                numberOfPumpDead++;
            }
        }

        for(int i = 0; i < numberOfPumpDead; ++i)
        {
            if(_objectToHideByPumpDeath.Length <= i)
            {
                return;
            }
            _objectToHideByPumpDeath[i].SetActive(false);
        }
    }
}
