using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Pompes : MonoBehaviour
{
    Health _health;
    void Start()
    {
        _health = GetComponent<Health>();
        _health._onHealthChanged += OnReceiveDamage;
    }

    void OnReceiveDamage()
    {
        //_health._currentHealth 
    }
}
