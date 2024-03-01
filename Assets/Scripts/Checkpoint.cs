using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject[] activationItems;

    public void Activate(bool b)
    {
        foreach (var item in activationItems)
        {
            item.SetActive(b);
        }
    }
}
