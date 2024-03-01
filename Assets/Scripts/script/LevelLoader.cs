using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int[] _scenesIndexesToLoad;

    void Start()
    {
#if !UNITY_EDITOR
        foreach(int scenesIndexes in _scenesIndexesToLoad)
        {
            SceneManager.LoadScene(scenesIndexes, LoadSceneMode.Additive);
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
