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
    Transform Player;
    Transform Target;

    PlayerTriggerDetector playerTriggerDetector;

    void Start()
    {
        playerTriggerDetector = FindObjectOfType<PlayerTriggerDetector>();
        Player = GameObject.FindWithTag("Player").transform; 
        
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

        Vector3 offset = Vector3.up * 1.5f;
        gameObject.transform.LookAt(Player.transform.position + offset);
        var move = Speed_boulet * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position + offset, move);


        Destroy(gameObject, 20.0f);
    }
    
   
    private void OnCollisionEnter(Collision collision)
    {

       
        if (collision.collider.CompareTag ("Player"))
        {
            IsPlayerInRange = true;
            Timer = 0;
            Destroy(gameObject);
            playerTriggerDetector.LoseHealth(10);

        }

        if(collision.collider.CompareTag("BossHeart"))
        {
            Destroy(gameObject);
            Timer = 0;
        }

        if(collision.collider.tag == "Minion_Boss")
        {
            Destroy(gameObject);
            Timer = 0;
        }
    }
}

