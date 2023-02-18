using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers _instance;

    private SceneManager sceneManager;
    private GameManager gameManager;
    private UIManager uiManager;
    private EnemySpawner spawner;

    public static SceneManager SceneManager { get { return _instance.sceneManager; } }
    public static GameManager GameManager { get { return _instance.gameManager; } }
    public static UIManager UIManager { get { return _instance.uiManager; } }
    public static EnemySpawner Spawner { get { return _instance.spawner; } }

    T Allocation<T>() where T : ManagerBase
    {
        T _object = null;
        _object = transform.GetComponent<T>();
        if(_object == null)
        {
            _object = gameObject.AddComponent<T>();
        }

        return _object;
    }

    void Awaking<T>(out T _object) where T : ManagerBase
    {
        _object = Allocation<T>();
        _object.Init();
    }

    void Init()
    {
        Awaking<SceneManager>(out sceneManager);
        Awaking<UIManager>(out uiManager);

        Awaking<GameManager>(out gameManager);

        spawner = GetComponent<EnemySpawner>();
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
