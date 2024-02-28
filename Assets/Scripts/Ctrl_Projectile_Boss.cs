using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ctrl_Projectile_Boss : MonoBehaviour
{
    public float Timer;
    bool IsPlayerInRange;
    public GameObject Boulet;
    public GameObject FxBoulet;
    float direction;
    float Speed_boulet;
    GameObject Player;
    Transform Target;
    void Start()
    {
        Player = Player = GameObject.FindWithTag("Player");
        Speed_boulet = 5.0f;
        Target = Player.transform;
        Target.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (distance <= 20.0f)
        {
            IsPlayerInRange = true;
            
            

        }*/
    }
    private void FixedUpdate()
    {
        Timer = Timer + Time.deltaTime;

        gameObject.transform.LookAt(Player.transform.position + Vector3.up * 2.0f);
        var move = Speed_boulet * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, move);


        Destroy(gameObject, 20.0f);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInRange = false;
            Timer = 0;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

       
        if (collision.collider.CompareTag ("Player"))
        {
            IsPlayerInRange = true;
            Timer = 0;
            Destroy(gameObject);

        }

        if(collision.collider.CompareTag("BossHeart"))
        {
            Destroy(gameObject);
            Timer = 0;
        }
    }
}

