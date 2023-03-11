using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : SceneUIBase
{
    private Transform _canvas;

    private Text _timeT;
    private Text _scoreT;

    private int _time;
    private int _score;

    public override void OnShow()
    {
        _canvas = transform.Find("InGameUI");
        Managers.UIManager.SetCanvas(_canvas);
        _timeT = _canvas.Find("TimeBox").GetComponentInChildren<Text>();
        _scoreT = _canvas.Find("ScoreBox").GetComponentInChildren<Text>();
        Clear();

        if (isAwaking)
        {
            return;
        }
    }

    void Clear()
    {
        _score = 0;
        _time = 0;

        _scoreT.text = "000000000000000";
        _timeT.text = "00 : 00";

        transform.Find("Player").GetComponent<PlayerController>().Play();
    }

    public void SetScore(int score)
    {
        _score = score;

        _scoreT.text = "";

        for (int i = 0; i < 15; i++)
        {
            if (_score >= 10)
            {
                _scoreT.text = $"{_score % 10}{_scoreT.text}";
                _score /= 10;
            }
            else if (_score != 0)
            {
                _scoreT.text = $"{_score}{_scoreT.text}";
                _score = 0;
            }
            else
            {
                _scoreT.text = $"0{_scoreT.text}";
            }
        }
    }

    public void SetTimer(float time)
    {
        _time = (int)time;

        _timeT.text = "";

        if ((_time / 60) < 10)
        {
            _timeT.text = "0";
        }
        _timeT.text += $"{_time / 60}:";

        if ((_time % 60) < 10)
        {
            _timeT.text += "0";
        }
        _timeT.text += $"{_time % 60}";

        _time = 0;
    }
}
