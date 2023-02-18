using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerBase
{
    [Header("---Test table---")]
    public bool isTastPlay;
    [Space(5)]
    [Header("Test table")]
    public Define.Scenes startScene;

    public int _score;
    public float _time;

    public override void Init()
    {
        if (isTastPlay)
        {
            Managers.SceneManager.LoadScene(startScene);
        }
        else
        {
            Managers.SceneManager.LoadScene(Define.Scenes.Title);
        }
    }

    public void OnGame()
    {
        _score = 0;
        _time = 0;
    }
}
