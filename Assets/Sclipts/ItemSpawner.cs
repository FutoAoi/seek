using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSpawnSetting
{
   [SerializeField] public Transform SpawnPoint;
   [SerializeField] public GameObject[] SpawnItems;
}

public class ItemSpawner : MonoBehaviour
{
    [Header("èoåªà íu")]
    [SerializeField] public ItemSpawnSetting[] SpawnItems;

    int _spawnIndex;
    GameObject _spawnItem;

    private void Start()
    {
        foreach (var item in SpawnItems)
        {
            if (item.SpawnPoint == null || item.SpawnItems == null || item.SpawnItems.Length == 0) continue;

            _spawnIndex = Random.Range(0, item.SpawnItems.Length);
            _spawnItem = item.SpawnItems[_spawnIndex];

            Instantiate(_spawnItem, item.SpawnPoint.position, Quaternion.identity);
        }
    }
}
