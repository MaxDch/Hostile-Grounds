using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerDetector : MonoBehaviour
{
    [SerializeField] int lavaDamage;
    [SerializeField] float lavaDamageCooldown;
    [SerializeField] float gameOverDuration;
    [SerializeField] float gameOverPostDelay;
    [SerializeField] float endGameOverDuration;
    [SerializeField] ThirdPersonController thirdPersonController;
    [SerializeField] GameObject bossCamera;
    Health _health;

    [SerializeField] ParticleSystem damageParticle;


    float currentLavaDamageCooldown;

    float DistanceBetweenPlayer = 5.0f;

    Vector3 startPosition;

    UIManager uIManager;

    Checkpoint currentCheckpoint;

    bool isOnLava;

    bool isInGameOver;

    void Start()
    {
        startPosition = transform.position;
        uIManager = FindObjectOfType<UIManager>();

        _health = thirdPersonController.GetComponent<Health>();
        _health._onDeath += StartCoroutineGameOver;

        bossCamera = null;
    }

    private void StartCoroutineGameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    void Update()
    {
        if (isOnLava && currentLavaDamageCooldown <= 0)
        {
            _health.Damage(lavaDamage);
            currentLavaDamageCooldown = lavaDamageCooldown;
        }
        else if(currentLavaDamageCooldown > 0)
        {
            currentLavaDamageCooldown -= Time.deltaTime;
        }
    }

    IEnumerator GameOverRoutine()
    {
        isInGameOver = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(gameOverDuration);
        Respawn();
    }

    void Respawn()
    {
        if (bossCamera != null)
        {
            bossCamera.SetActive(false);
        }
        _health.Respawn();
        gameObject.SetActive(false);
        transform.position = currentCheckpoint != null ? currentCheckpoint.transform.position : startPosition;
        gameObject.SetActive(true);
        Time.timeScale = 1;
        isOnLava = false;
        thirdPersonController.enabled = false;
        StartCoroutine(ReplayAfterDelay());
    }

    IEnumerator ReplayAfterDelay()
    {
        yield return new WaitForSeconds(gameOverPostDelay);
        uIManager.EndGameOver();

        yield return new WaitForSeconds(endGameOverDuration);
        thirdPersonController.enabled = true;
        isInGameOver = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            isOnLava = true;
        }
        else if (other.CompareTag("ShieldBoss"))
        {
            print("J'approche du bouclier");
            Vector3 Bouclier = other.transform.position - transform.position;
            float sqrLen = Bouclier.sqrMagnitude;
            if (sqrLen <= DistanceBetweenPlayer * DistanceBetweenPlayer)
            {
                _health.Damage(10);
            }
        }
        
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossCamera = bossControl.bossCamera;
            bossCamera.SetActive(true);
        }
        if (other.TryGetComponent<Checkpoint>(out var checkpoint))
        {
            if (checkpoint != currentCheckpoint)
            {
                if (currentCheckpoint != null)
                {
                    currentCheckpoint.Activate(false);
                }
                checkpoint.Activate(true);
                currentCheckpoint = checkpoint;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossCamera.SetActive(false);
        }
        if (other.CompareTag("Lava"))
        {
            isOnLava = false;
        }
    }

}
