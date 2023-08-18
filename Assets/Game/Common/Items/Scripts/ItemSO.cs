using UnityEngine;

[CreateAssetMenu(fileName = "item_", menuName = "ScriptableObjects/Common/Items/Generic Item")]
public class ItemSO : ScriptableObject
{
    [Header("Main Configuration")]
    [SerializeField] private string id = string.Empty;
    [SerializeField] private Sprite icon = null;

    public string Id { get => id; }
    public Sprite Icon { get => icon; }
}
