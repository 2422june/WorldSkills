using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MapManager _mapManager;

    private bool _isGameStart = false;

    private Transform _player;
    private Transform Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return _player;
        }

        set { _player = value; }
    }

private Vector3 _playerDir;
    private Ray _ray;
    private RaycastHit _hit;
    private Transform _pushingBox;

    private bool _isMoving;
    private Transform _moveObject;
    private Vector3 _destination;
    private int _stayScore;

    [SerializeField]
    private GameObject _clearPanel;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        _isGameStart = false;

        _clearPanel.SetActive(false);

        _mapManager = GetComponent<MapManager>();

        _mapManager.Init();
    }

    public void OnMapSetting()
    {
        _clearScore = _mapManager.GetData();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        _isGameStart = true;
    }

    void Moving()
    {
        _moveObject.position = Vector3.Lerp(_moveObject.position, _destination, Time.deltaTime * 10f);

        if(Vector3.Distance(_moveObject.position, _destination) <= 0.1f)
        {
            _moveObject.position = _destination;
            _moveObject = null;
            _destination = Vector3.zero;
            _isMoving = false;
            AddScore(0);
        }
    }

    void SetMove(Transform moveObject, Vector3 dir)
    {
        _moveObject = moveObject;
        _destination = _moveObject.position + dir;
        _isMoving = true;
    }

    void Update()
    {
        if (!_isGameStart)
            return;

        if (_isMoving)
        {
            Moving();
            return;
        }

        _playerDir = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow)) _playerDir.x = 1;
        if (Input.GetKey(KeyCode.LeftArrow))  _playerDir.x = -1;
        if (Input.GetKey(KeyCode.UpArrow))    _playerDir.z = 1;
        if (Input.GetKey(KeyCode.DownArrow))  _playerDir.z = -1;

        if (_playerDir == Vector3.zero)
            return;

        _ray.origin = Player.position;
        _ray.direction = _playerDir;

        if (Physics.Raycast(_ray, out _hit, 1f))
        {
            if (_hit.transform.CompareTag("Box"))
            {
                _pushingBox = _hit.transform;
                _ray.origin = _pushingBox.position;
                _ray.direction = _playerDir;

                if (Physics.Raycast(_ray, out _hit, 1f))
                {
                    if(_hit.transform != _pushingBox && !_hit.transform.CompareTag("Goal"))
                    {
                        // can't push
                        return;
                    }
                }

                //------- can push

                SetMove(_pushingBox, _playerDir);
                //_pushingBox.position += _playerDir;

                //-------

            }//box
            else if (_hit.transform == Player || _hit.transform.CompareTag("Goal"))
            {
                SetMove(Player, _playerDir);
                //_player.position += _playerDir;
            }
        }
        else
        {
            SetMove(Player, _playerDir);
            //_player.position += _playerDir;
        }
    }



    private int _clearScore;
    private int _score = 0;

    public void AddScore(int score)
    {
        if(_isMoving)
        {
            _stayScore += score;
            return;
        }

        _score += _stayScore;
        _stayScore = 0;
        if (_score >= _clearScore)
        {
            _clearPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
