using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : SceneUIBase
{
    private Transform _canvas;
    private Button startButton;
    private Button backButton;
    private Text[] _bestScore = new Text[5];

    public override void OnShow()
    {
        _canvas = Managers.UIManager.SetCanvas("Lobby");
        startButton = Managers.UIManager.Find<Button>("Button");
        backButton = Managers.UIManager.Find<Button>("Back");
        startButton.onClick.AddListener(OnClickStartButton);
        backButton.onClick.AddListener(OnClickExitButton);

        for(int i = 1; i <= 5; i++)
        {
            _bestScore[i-1] = _canvas.Find($"Score{i}").GetComponentInChildren<Text>();
        }

        for(int i = 0; i < 5; i++)
        {
            _bestScore[i].text = SetScore(i);
        }
    }

    void OnClickStartButton()
    {
        Managers.SceneManager.LoadScene(Define.Scenes.InGame);
    }

    void OnClickExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    string SetScore(int index)
    {
        int score = Managers.GameManager._bestScore[index];

        string text = "";

        for (int i = 0; i < 15; i++)
        {
            if (score >= 10)
            {
                text = $"{score % 10}{text}";
                score /= 10;
            }
            else if (score != 0)
            {
                text = $"{score}{text}";
                score = 0;
            }
            else
            {
                text = $"0{text}";
            }
        }

        return text;
    }
}
