using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiegeMonstre : MonoBehaviour
{
    public float TimerPiege;
    public GameObject ZonePiege;
    public GameObject FxOnActif;
    

    // Dégâts de Zone toutes les 10 secondes
    void Start()
    {
        TimerPiege = 0;
        ZonePiege.SetActive(false);
        FxOnActif.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerPiege = TimerPiege + Time.deltaTime; // timer en seconde 
        if (TimerPiege >= 5.00 && TimerPiege <= 10.0)
        {
            Debug.Log("Le piège s'active");
            ZonePiege.SetActive(true);
            FxOnActif.SetActive(true);
        }
        if (TimerPiege >= 10.0)
        {
            TimerPiege = 0;
            ZonePiege.SetActive(false);
            FxOnActif.SetActive(false);
        } 
    }

    

}