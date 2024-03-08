using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl_Pompes : MonoBehaviour
{
    Health _health;
    public Slider _healthBar;
    void Start()
    {
        _health = GetComponent<Health>();
        _health._onHealthChanged += OnReceiveDamage;
        _healthBar.value = 100;
        
    }

    void OnReceiveDamage()
    {
        _healthBar.value = _health._currentHealth;

        //_health._currentHealth 
    }
}
