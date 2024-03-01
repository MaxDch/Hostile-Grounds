using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerHealth;

    [SerializeField] Animator gameOverUIAnimator;

    public void PlayGameOver()
    {
        gameOverUIAnimator.SetBool("Play", true);
    }

    public void EndGameOver()
    {
        gameOverUIAnimator.SetBool("Play", false);
    }
}
