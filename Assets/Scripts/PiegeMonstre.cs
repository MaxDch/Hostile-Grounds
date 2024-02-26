using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeMonstre : MonoBehaviour
{
    public float mytimer;
    public GameObject ZonePiege;
    public GameObject FxOnActif;
    // Start is called before the first frame update
    void Start()
    {
        ZonePiege.SetActive(false);
        FxOnActif.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mytimer = mytimer + Time.deltaTime; // timer en seconde 
        if (mytimer >= 20.00 && mytimer <= 22) ;
        {
            Debug.Log("20s sont passer attention");
            ZonePiege.SetActive(true);
            FxOnActif.SetActive(true);
        }
        if (mytimer >= 22) ;
        {
            mytimer = 0;
            ZonePiege.SetActive(false);
            FxOnActif.SetActive(false);
        }
    }
}
