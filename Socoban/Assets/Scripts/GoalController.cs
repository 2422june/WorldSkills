using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Box"))
        {
            _gameManager.AddScore(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            _gameManager.AddScore(-1);
        }
    }
}
