using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int[] _scenesIndexesToLoad;

    void Start()
    {
        foreach(int scenesIndexes in _scenesIndexesToLoad)
        {
            SceneManager.LoadScene(scenesIndexes, LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
