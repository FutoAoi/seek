using UnityEngine;

public enum ItemTier
{
    Common,
    Rare,
    Epic,
    Legendary
}

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    [Header("アイテムリスト")]
    [SerializeField] GameObject[] _commonItem;
    [SerializeField] GameObject[] _rareItem;
    [SerializeField] GameObject[] _epicItem;
    [SerializeField] GameObject[] _legengaryItem;

    GameObject[] list;
    int index;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public GameObject GetRandomItem(ItemTier tier)
    {
        list = null;
        switch(tier)
        {
            case ItemTier.Common:    list = _commonItem; break;
            case ItemTier.Rare:      list = _rareItem; break;
            case ItemTier.Epic:      list = _epicItem; break;
            case ItemTier.Legendary: list = _legengaryItem; break;
        }

        if(list == null || list.Length == 0) return null;

        index = Random.Range(0, list.Length);
        return list[index];
    }
}
