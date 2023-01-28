using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : SceneUIBase
{
    private Transform _canvas;
    private GameObject _mainCamera, _inGameCamera;

    public override void OnShow()
    {
        if (isAwaking)
            return;
        //_mainCamera = GameObject.Find("MainCamera");
        //_inGameCamera = GameObject.Find("InGameCamera");
        //SwitchCamera();
        //_canvas = Managers.UIManager.SetCanvas("InGame");
    }

    public void SwitchCamera()
    {
        bool isActive;
        isActive = _mainCamera.activeSelf;
        _mainCamera.SetActive(!isActive);
        _inGameCamera.SetActive(isActive);
    }
}
