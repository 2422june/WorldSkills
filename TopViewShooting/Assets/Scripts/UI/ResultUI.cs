using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : SceneUIBase
{
    private Transform _canvas;
    private Button GoToLobby;
    private Text _scoreT;

    public override void OnShow()
    {
        Managers.GameManager.SetBestScore();
        _canvas = Managers.UIManager.SetCanvas("Result");
        GoToLobby = Managers.UIManager.Find<Button>("GoToLobby");
        _scoreT = _canvas.Find("Score").GetComponentInChildren<Text>();
        SetScore();

        if (isAwaking)
        {
            return;
        }
        
        GoToLobby.onClick.AddListener(OnClickGoToLobby);
    }

    void OnClickGoToLobby()
    {
        Managers.SceneManager.LoadScene(Define.Scenes.Lobby);
    }
    
    void SetScore()
    {
        int score = Managers.GameManager._score;

        _scoreT.text = "";

        for (int i = 0; i < 15; i++)
        {
            if (score >= 10)
            {
                _scoreT.text = $"{score % 10}{_scoreT.text}";
                score /= 10;
            }
            else if (score != 0)
            {
                _scoreT.text = $"{score}{_scoreT.text}";
                score = 0;
            }
            else
            {
                _scoreT.text = $"0{_scoreT.text}";
            }
        }
    }
}
