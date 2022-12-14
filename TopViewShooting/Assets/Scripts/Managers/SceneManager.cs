using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseSceneManager = UnityEngine.SceneManagement;
using sceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : ManagerBase
{
    private List<GameObject> _scenes = new List<GameObject>();
    private int _nowScene;

    public override void Init()
    {
        _nowScene = 0;

        _scenes.Clear();
        for(int i = 0; i < System.Enum.GetValues(typeof(Define.Scenes)).Length; i++)
        {
            _scenes.Add(null);
        }
        SetNewScene(Define.Scenes.None);
        //sceneManager.sceneLoaded += OnLoadScene;
    }

    public void LoadScene(Define.Scenes name)
    {
        if(_scenes[(int)name] == null)
        {
            SetNewScene(name);
        }
        _scenes[(int)name].SetActive(true);
        _scenes[_nowScene].SetActive(false);

        _nowScene = (int)name;
        OnLoadScene();

        //sceneManager.LoadScene(name.ToString());
    }

    public void SetNewScene(Define.Scenes name)
    {
        _scenes[(int)name] = Instantiate(Resources.Load<GameObject>($"Scenes/{name.ToString()}"));
        _scenes[(int)name].name = name.ToString();
    }

    //public void OnLoadScene(baseSceneManager.Scene scene, baseSceneManager.LoadSceneMode mode)
    void OnLoadScene()
    {
        _scenes[_nowScene].GetComponent<SceneUIBase>().OnShow();
    }
}
