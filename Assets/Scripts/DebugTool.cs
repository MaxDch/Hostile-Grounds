using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    [SerializeField] Transform transformToTeleport;
    [SerializeField] Transform teleportDestination;

    [SerializeField] GameObject debugRoot;

    bool isPlaying;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isPlaying = !isPlaying;
            if(isPlaying)
            {
                Cursor.lockState = CursorLockMode.None;
                debugRoot.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                debugRoot.SetActive(false);
            }
        }
    }

    public void Teleport()
    {
        Debug.Log("Teleport");
        transformToTeleport.gameObject.SetActive(false);
        transformToTeleport.position = teleportDestination.position;
        transformToTeleport.gameObject.SetActive(true);
    }
}
