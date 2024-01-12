using UnityEngine;

namespace BlueGravity.Common.Currencies
{
    [CreateAssetMenu(fileName = "currency_", menuName = "ScriptableObjects/Common/Currencies/Currency")]
    public class CurrencySO : ScriptableObject
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private string id = null;
        [SerializeField] private Sprite icon = null;
        #endregion

        #region PROPERTIES
        public string Id { get => id; }
        public Sprite Icon { get => icon; }
        #endregion
    }
}