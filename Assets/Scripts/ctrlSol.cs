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
        gamemanager.PV = gamemanager.PV - 100;
        Debug.Log("vie = " + gamemanager.PV.ToString());
        valeurPV.GetComponent<Text>().text = gamemanager.PV.ToString();
    }
}
