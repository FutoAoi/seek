using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] public List<GameObject> MapDates;
    [SerializeField] int _mapSize = 25;
    [SerializeField] int _mapVertical = 2;
    [SerializeField] int _mapHorizontal = 2;
    void Start()
    {
        for (int i = 0; i < _mapHorizontal; i++)
        {
            for (int j = 0; j < _mapVertical; j++)
            {
                Instantiate(MapDates[0], new Vector3(i *  _mapSize, 0, j * _mapSize), Quaternion.identity);
            }
        }


    }
}
