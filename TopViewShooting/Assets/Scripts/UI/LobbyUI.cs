using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : SceneUIBase
{
    private Transform _canvas;
    private Button startButton;
    private Button backButton;

    public override void OnShow()
    {
        base.OnShow();
        _canvas = Managers.UIManager.SetCanvas("Lobby");
        startButton = Managers.UIManager.Find<Button>("Button");
        backButton = Managers.UIManager.Find<Button>("Back");
        startButton.onClick.AddListener(OnClickStartButton);
        backButton.onClick.AddListener(OnClickBackButton);
    }

    void OnClickStartButton()
    {
        Managers.SceneManager.LoadScene(Define.Scenes.InGame);
    }

    void OnClickBackButton()
    {
        Managers.SceneManager.LoadScene(Define.Scenes.Title);
    }
}
