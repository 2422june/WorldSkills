using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseSceneManager = UnityEngine.SceneManagement;
using sceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public void Init()
    {
        sceneManager.sceneLoaded += OnLoadScene;
    }

    public void LoadScene(Define.Scenes name)
    {
        sceneManager.LoadScene(name.ToString());
    }

    public void OnLoadScene(baseSceneManager.Scene scene, baseSceneManager.LoadSceneMode mode)
    {

    }
}
