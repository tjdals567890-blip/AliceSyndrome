using UnityEngine;

public enum ItemType 
{
    Consumable,
    KeyItem,
    Document
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
    [TextArea] public string itemDescription;
}
