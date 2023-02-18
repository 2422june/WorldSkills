using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : ManagerBase
{
    [Header("---Test table---")]
    public bool isTastPlay;
    [Space(5)]
    [Header("Test table")]
    public Define.Scenes startScene;

    [Header("---InGame table---")]
    public int _score;
    public float _time;
    public bool _isInGame;
    private InGameUI _inGameUI;

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
        _isInGame = true;
        _score = 0;
        _time = 0;
        Managers.Spawner.SetSpawnig();

        _inGameUI = GameObject.Find("InGame").GetComponentInChildren<InGameUI>();
    }

    void Update()
    {
        if (!_isInGame)
            return;

        _time += Time.deltaTime;
        _inGameUI.SetTimer(_time);
    }

    public void AddScore(int value)
    {
        _score += value;
        _inGameUI.SetScore(_score);
    }
}
