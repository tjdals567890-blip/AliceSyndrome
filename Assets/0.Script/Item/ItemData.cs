using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "TestItem")]
public class ItemData : ScriptableObject
{
    public string itemId;
    public string itemName;
    [TextArea] public string text;
    public Sprite icon;
}
