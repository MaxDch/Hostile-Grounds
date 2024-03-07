using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Destroy(gameObject, 50.0f);
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
        if(playerTriggerDetector.GetComponent<Health>().IsDead())
        {
            Destroy(gameObject);
        }

        Vector3 offset = Vector3.up * 1.5f;
        gameObject.transform.LookAt(Target.transform.position + offset);
        var move = Speed_boulet * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position + offset, move);
        
    }
}

