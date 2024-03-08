using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RePlayGame()
    {
        SceneManager.LoadScene("Scene_principal");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
