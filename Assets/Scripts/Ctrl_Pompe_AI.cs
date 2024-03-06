using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ctrl_Pompe_AI : MonoBehaviour
{
    public NavMeshAgent Minion;
    public GameObject SpawnPoint;
    
    void Start()
    {
        Minion = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        { 
            Instantiate(Minion, SpawnPoint.transform.position, Quaternion.identity);
        
        }
    }

}
