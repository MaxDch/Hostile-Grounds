using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonePiegePilier : MonoBehaviour
{
    public GameObject PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = GameObject.Find("ValeurHealth");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            gamemanager.Health = gamemanager.Health - 10;
            PlayerHealth.GetComponent<Text>().text = gamemanager.Health.ToString();
        }



    }
}
