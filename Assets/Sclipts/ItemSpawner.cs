using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("�X�|�[���|�C���g�̐ݒ�")]
    [SerializeField] ItemTier _spawnTier;

    GameObject _spawnItem;

    private void Start()
    {
        _spawnItem = ItemDatabase.instance.GetRandomItem(_spawnTier);
        Instantiate(_spawnItem, transform.position, Quaternion.identity);
    }
}
