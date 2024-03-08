using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl_Pompes : MonoBehaviour
{
    Health _health;
    public Slider _healthBar;
    public Health[] _pumpsParts;
    public GameObject[] _objectToHideByPartDamaged;
    void Start()
    {
        _health = GetComponent<Health>();
        _health._onHealthChanged += OnReceiveDamage;
        _healthBar.value = 100;
        foreach (Health health in _pumpsParts)
        {
            health._onDeath += OnReceiveDamage;
        }
    }

    void OnReceiveDamage()
    {
        _healthBar.value = _health._currentHealth;

        // _health._currentHealth 
        int numberOfPumpPartDead = 0;

        foreach (Health health in _pumpsParts)
        {
            if (health.IsDead())
            {
                numberOfPumpPartDead++;
            }
        }

        for (int i = 0; i < numberOfPumpPartDead; ++i)
        {
            if (_objectToHideByPartDamaged.Length <= i)
            {
                return;
            }
            _objectToHideByPartDamaged[i].SetActive(false);
        }
    }
}
