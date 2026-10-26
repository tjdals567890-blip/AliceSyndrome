using UnityEngine;
using System.Collections.Generic;
using System;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    [SerializeField] List<ItemData> items = new List<ItemData>();
    [SerializeField] ItemData testItem;

    public IReadOnlyList<ItemData> Items => items;

    public event Action<ItemData> OnInventoryChanged; //나중에 인벤토리UI에 보낼 이벤트

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
        if (item == null)
            return;

        items.Add(item);
        OnInventoryChanged?.Invoke(item);
    }
    public void RemoveItem(ItemData item)
    {
        if (item == null)
            return;
        if (!items.Remove(item))
            return;

        OnInventoryChanged?.Invoke(item);
    }

    public bool HasItem(string itemId)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null && items[i].itemId == itemId)
                return true;
        }
        return false;
    }
    
    public bool HasItem(ItemData item)
    {
        return item != null && items.Contains(item);
    }
    
    [ContextMenu("Test Add Item")]
    void TestAddItem()
    {
        AddItem(testItem);
    }
}
