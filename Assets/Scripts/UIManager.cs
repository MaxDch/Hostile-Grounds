using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PlayerHealth;

    [SerializeField] Animator gameOverUIAnimator;
    Health _playerHealth;
    private void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        _playerHealth._onDeath += PlayGameOver;
        _playerHealth._onHealthChanged += UpdateHealthUI;
    }

    public void UpdateHealthUI()
    {
        PlayerHealth.SetText(_playerHealth._currentHealth.ToString());
    }

    private void PlayGameOver()
    {
        gameOverUIAnimator.SetBool("Play", true);
    }

    public void EndGameOver()
    {
        gameOverUIAnimator.SetBool("Play", false);
    }
}
