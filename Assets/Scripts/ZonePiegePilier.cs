using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonePiegePilier : MonoBehaviour
{
    [SerializeField] float attackDelay;

    PlayerTriggerDetector playerTriggerDetector;

    bool isPlayerInTrigger;

    float currentAttackDelay;

    void Start()
    {
        playerTriggerDetector = FindObjectOfType<PlayerTriggerDetector>();
    }

    void Update()
    {
        if(currentAttackDelay <= 0 && isPlayerInTrigger)
        {
            bool isDead = playerTriggerDetector.LoseHealth(10);
            if(isDead)
            {
                isPlayerInTrigger = false;
            }
            currentAttackDelay = attackDelay;
        }
        else if(currentAttackDelay > 0)
        {
            currentAttackDelay -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            currentAttackDelay = attackDelay;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
