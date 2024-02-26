using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlSol : MonoBehaviour
{
    public GameObject valeurPV;
    public GameObject zonepiege;

    // Start is called before the first frame update
    void Start()
    {
        zonepiege.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* private void OnTriggerEnter(Collider other)
    {
        gamemanager.Health = gamemanager.Health - 100;
        Debug.Log("vie = " + gamemanager.Health.ToString());
        valeurPV.GetComponent<Text>().text = gamemanager.Health.ToString();
    } */
} 
