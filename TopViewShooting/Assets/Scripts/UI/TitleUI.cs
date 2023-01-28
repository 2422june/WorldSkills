using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : SceneUIBase
{
    private Transform _canvas;
    private Button startButton;

    public override void OnShow()
    {
        if (isAwaking)
            return;

        _canvas = Managers.UIManager.SetCanvas("Title");
        startButton = Managers.UIManager.Find<Button>("Button");
        startButton.onClick.AddListener(OnClickStartButton);
    }

    void OnClickStartButton()
    {
        Managers.SceneManager.LoadScene(Define.Scenes.Lobby);
    }
}
