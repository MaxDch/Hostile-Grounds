using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Projectile_Boss : MonoBehaviour
{
    public float Timer;
    bool IsPlayerInRange;
    public GameObject Boulet;
    public GameObject FxBoulet;
    float distance;
    float Speed_boulet;
    GameObject Player;
    void Start()
    {
        Player = Player = GameObject.FindWithTag("Player");
        Speed_boulet = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        if (distance <= 20.0f)
        {
            IsPlayerInRange = true;
            gameObject.transform.LookAt(Player.transform.position);
            Vector3 direction = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, 10.0f);
            direction = Vector3.Normalize(direction) * Speed_boulet * Time.deltaTime;
            
            Destroy(gameObject, 20.0f);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInRange = true;
            Timer = 0;
            Destroy(gameObject);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInRange = false;
            Timer = 0;

        }
    }

}

