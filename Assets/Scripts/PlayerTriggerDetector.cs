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
    }

    void Update()
    {
        if (isOnLava && currentLavaDamageCooldown <= 0)
        {
            LoseHealth(lavaDamage);
            currentLavaDamageCooldown = lavaDamageCooldown;
        }
        else if(currentLavaDamageCooldown > 0)
        {
            currentLavaDamageCooldown -= Time.deltaTime;
        }
    }

    IEnumerator GameOverRoutine()
    {
        uIManager.PlayGameOver();
        isInGameOver = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(gameOverDuration);
        Respawn();
    }

    void Respawn()
    {
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
        gamemanager.Health = 100;
        yield return new WaitForSeconds(endGameOverDuration);
        thirdPersonController.enabled = true;
        isInGameOver = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && other.TryGetComponent<Ctrl_Boulet_Pilier>(out var projectile))
        {
            LoseHealth(10);
            projectile.Explode();
        }
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
                LoseHealth(10);
            }
        }
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossControl.SwapBossCameraActivation(true);
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

    public bool LoseHealth(int losedHealth)
    {
        if (isInGameOver == false)
        {
            gamemanager.Health = Mathf.Max(gamemanager.Health - losedHealth, 0);
            damageParticle.Play();
            if(uIManager == null)
            {
                Debug.LogError("UI Manager is null");
            }
            else if(uIManager.PlayerHealth == null)
            {
                Debug.LogError("PlayerHealth is null");
            }
            uIManager.PlayerHealth.text = gamemanager.Health.ToString();

            if (gamemanager.Health <= 0)
            {
                StartCoroutine(GameOverRoutine());
                return true;
            }
        }
        return false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossControl.SwapBossCameraActivation(false);
        }
        if (other.CompareTag("Lava"))
        {
            isOnLava = false;
        }
    }

}
