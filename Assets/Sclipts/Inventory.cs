using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] ItemData[] HaveItem = new ItemData[14];
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(ItemData item)
    {
        for (int i = 0;i < HaveItem.Length;i++)
        {
            if (HaveItem[i] != null) continue;
            HaveItem[i] = item;
            break;
        }
        Debug.Log(item.ItemName + "‚ð“üŽè‚µ‚½");
    }
}
