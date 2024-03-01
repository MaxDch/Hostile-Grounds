using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CtrlShieldBoss : MonoBehaviour
{
    public float AttackZone;
    public float DamageCooldown;

    GameObject Player;
    public GameObject Shield;

    float currentDamageCooldown;
    float currentDistance;

    UIManager uIManager;

    public GameObject playerNearSign;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        Player = GameObject.FindWithTag("Player");

        AttackZone = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(Shield.transform.position, Player.transform.position);

        if (currentDistance < AttackZone)
        {
            playerNearSign.SetActive(true);
            currentDamageCooldown += Time.deltaTime;
            if (currentDamageCooldown > DamageCooldown)
            {
                currentDamageCooldown = 0;
                gamemanager.Health = gamemanager.Health - 1;
                uIManager.PlayerHealth.text = gamemanager.Health.ToString();
                print("Je prends des dégâts");
            }
        }
        else
        {
            playerNearSign.SetActive(false);
            //currentDamageCooldown = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackZone);
    }
}
