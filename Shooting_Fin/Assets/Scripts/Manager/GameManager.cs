using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _playerHP, _playerOil;

    public void SynchPlayerHP(int hp)
    {
        _playerHP = hp;
    }

    public void SynchPlayerOil(int oil)
    {
        _playerOil = oil;
    }
}
