using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] public List<GameObject> MapDates;
    [SerializeField] int _mapSize = 25;
    [SerializeField] int _mapVertical = 2;
    [SerializeField] int _mapHorizontal = 2;

    int _r;
    void Start()
    {
        for (int i = 0; i < _mapHorizontal; i++)
        {
            for (int j = 0; j < _mapVertical; j++)
            {
                _r = Random.Range(0, MapDates.Count);
                Instantiate(MapDates[_r], new Vector3(i *  _mapSize, 0, j * _mapSize), Quaternion.identity);
            }
        }


    }
}
