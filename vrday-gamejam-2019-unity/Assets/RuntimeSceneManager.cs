using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeSceneManager : MonoBehaviour
{

    void Start()
    {
        LoadThisScene(1);
        
    }

    public void LoadThisScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
