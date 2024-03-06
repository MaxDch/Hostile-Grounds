using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ctrl_Minions_Boss_AI : MonoBehaviour
{
    public NavMeshAgent Minion;
    public Transform Player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject MinionProjectile;
    public float Health;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float TimeBetweenAttacks;
    bool AlreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        Minion = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasingPlayer();
        if (playerInSightRange && playerInAttackRange) AttackingPlayer();
    }

    private void Patroling() 
    { 
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet)
            Minion.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //WalkedPoint Reached
        if (distanceToWalkPoint.magnitude <1.0f )
            walkPointSet = false;
    
    }
    private void SearchWalkPoint() 
    { 
        // calculate randompoint in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 1.5f, whatIsGround))
            walkPointSet = true;
    
    }
    private void ChasingPlayer() 
    {
        Minion.SetDestination(Player.position);
    }
    private void AttackingPlayer() 
    {
        //Make sure ennemy doesn't move
        Minion.SetDestination(transform.position);
        
        transform.LookAt(Player.transform.position);

        if(!AlreadyAttacked) 
        {
            Rigidbody rb = Instantiate(MinionProjectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15.0f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5.0f, ForceMode.Impulse);
            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    
    }

    private void ResetAttack() 
    {
        AlreadyAttacked = false;
    }

    public void TakeDamage(int Damage) 
    {
        Health -= Damage;

        if (Health < 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy() 
    {
        Destroy(gameObject);
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
