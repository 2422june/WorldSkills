using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    //0 : Nothing
    //1 : Wall
    //2 : Box
    //3 : Player
    //4 : Goal

    [SerializeField]
    private GameObject[] prefabs;
    private List<GameObject> objects = new List<GameObject>();

    private Define.MapInfo _firstInfo;

    public Define.MapInfo GetMapData()
    {
        return _firstInfo;
    }
    public int GetData()
    {
        return _firstInfo._clearScore;
    }

    public void Init()
    {
        while(objects.Count > 0)
        {
            Destroy(objects[0]);
        }
        objects.Clear();

        int[,] _mapInfo = {
            { 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 1, 1, 1, 0, 0, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 1, 0, 0, 2, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1},
            { 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 4, 4, 1},
            { 1, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 1},
            { 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 3, 1, 1, 0, 0, 4, 4, 1},
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        _firstInfo._mapInfo = _mapInfo;
        _firstInfo._playerPos.z = 3;
        _firstInfo._playerPos.x = 11;
        _firstInfo._clearScore = 6;


        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if(_mapInfo[i, j] != 0)
                {
                    objects.Add(Instantiate(prefabs[_mapInfo[i, j] - 1], (Vector3.forward * (11 - i)) + (Vector3.right * j), Quaternion.identity));
                }
            }
        }
    }
}
