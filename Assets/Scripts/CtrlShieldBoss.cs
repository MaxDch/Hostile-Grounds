using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CtrlShieldBoss : MonoBehaviour
{
    public float AttackZone = 3.0f;
    public float DamageCooldown;

    Health Player;
    public GameObject Shield;

    float currentDamageCooldown;
    float currentDistance;

    UIManager uIManager;

    public GameObject playerNearSign;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        Player = GameObject.FindWithTag("Player").GetComponent<Health>();
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
                Player.Damage(1);
            }
        }
        else
        {
            playerNearSign.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackZone);
    }
}
