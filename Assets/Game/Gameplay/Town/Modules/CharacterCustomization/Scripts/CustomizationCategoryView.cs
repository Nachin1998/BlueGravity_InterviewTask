using System;

using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.Game.Hub.Modules.Customization
{
    public class CustomizationCategoryView : MonoBehaviour
    {
        #region EXOPSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private Button rightButton = null;
        [SerializeField] private Button leftButton = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init(string id, Action<string> onLeftPressed, Action<string> onRightPressed)
        {
            rightButton.onClick.AddListener(() => onRightPressed?.Invoke(id));
            leftButton.onClick.AddListener(() => onLeftPressed?.Invoke(id));
        }
        #endregion
    }
}