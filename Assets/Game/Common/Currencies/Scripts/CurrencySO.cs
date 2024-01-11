using UnityEngine;

namespace BlueGravity.Common.Currencies
{
    [CreateAssetMenu(fileName = "currency_", menuName = "ScriptableObjects/Common/Currencies/Currency")]
    public class CurrencySO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private string id = null;
        [SerializeField] private Sprite icon = null;

        public string Id { get => id; }
        public Sprite Icon { get => icon; }
    }
}