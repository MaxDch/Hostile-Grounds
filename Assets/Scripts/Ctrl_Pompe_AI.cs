using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ctrl_Pompe_AI : MonoBehaviour
{
    public GameObject Minion;
    public GameObject SpawnPoint;
    public bool _hasAlreadySpawn;
    
    void Start()
    {
        _hasAlreadySpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasAlreadySpawn)
        {
            Instantiate(Minion, SpawnPoint.transform.position, Quaternion.identity);
            _hasAlreadySpawn = true;



        }
        

        else if(other.CompareTag("Player") && _hasAlreadySpawn)
        {
            _hasAlreadySpawn = true;
            return;
        }
    }

}
