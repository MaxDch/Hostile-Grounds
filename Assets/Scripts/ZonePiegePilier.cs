using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonePiegePilier : MonoBehaviour
{
    [SerializeField] float attackDelay;

    Health _health;

    float currentAttackDelay;

    void Update()
    {
        if(currentAttackDelay <= 0 && _health != null)
        {
            _health.Damage(10);
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
            currentAttackDelay = attackDelay;
            _health = other.GetComponent<Health>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _health = null;
        }
    }

    private void OnDisable()
    {
        _health = null;
    }
}
