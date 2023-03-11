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

    [Header("---Lobby table---")]
    public int[] _bestScore = new int[5];

    public override void Init()
    {
        if (isTastPlay)
        {
            Managers.SceneManager.LoadScene(startScene);
        }
        else
        {
            LoadScore();

            Managers.SceneManager.LoadScene(Define.Scenes.Title);
        }
    }

    public void SaveScore()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt($"bestScore{i + 1}", _bestScore[i]);
        }
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        if(PlayerPrefs.HasKey("bestScore1"))
        {
            for(int i = 0; i < 5; i++)
            {
                _bestScore[i] = PlayerPrefs.GetInt($"bestScore{i+1}");
            }
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

    public void SetBestScore()
    {
        for(int i = 0; i < 5; i++)
        {
            if(_score >= _bestScore[i])
            {
                for(int j = 4; j > i; j--)
                {
                    _bestScore[j] = _bestScore[j-1];
                }
                _bestScore[i] = _score;
                break;
            }
        }
        SaveScore();
    }
}
