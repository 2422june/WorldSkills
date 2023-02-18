using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCanavs : MonoBehaviour
{
    private Slider _hpBar;

    public void Init(int maxHp)
    {
        _hpBar = GetComponentInChildren<Slider>();
        _hpBar.maxValue = maxHp;
        SetHPBar(maxHp);
    }

    public void SetHPBar(int hp)
    {
        _hpBar.value = hp;
    }
}
