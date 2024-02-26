using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlSol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gamemanager.PV = gamemanager.PV - 10;
    }
}
