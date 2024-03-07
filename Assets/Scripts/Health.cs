using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth = 100;

    public Action _onHealthChanged;
    public Action _onDeath;
    
    public void Respawn()
    {
        Heal(_maxHealth);
    }

    public void Damage(float damage)
    {    
        if(IsDead())
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        if(IsDead())
        {
            if (_onDeath != null)
            {
                _onDeath.Invoke();
            }
        }

        if (_onHealthChanged != null)
        {
            _onHealthChanged.Invoke();
        }
    }

    public void Heal(float damage)
    {
        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth + damage, 0, _maxHealth);

        if (_onHealthChanged != null)
        {
            _onHealthChanged.Invoke();
        }
    }

    public bool IsDead()
    {
        return _currentHealth == 0;
    }
}
