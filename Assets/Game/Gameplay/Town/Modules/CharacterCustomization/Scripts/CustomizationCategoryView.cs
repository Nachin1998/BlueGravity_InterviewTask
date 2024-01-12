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

        #region PRIVATE_FIELDS
        private string id = string.Empty;
        #endregion

        #region PROPERTIES
        public string Id { get => id; }
        #endregion

        #region PUBLIC_METHODS
        public void Init(string id, Action<string> onLeftPressed, Action<string> onRightPressed)
        {
            this.id = id;
            rightButton.onClick.AddListener(() => onRightPressed?.Invoke(id));
            leftButton.onClick.AddListener(() => onLeftPressed?.Invoke(id));
        }

        public void ToggleInteractability(bool status)
        {
            rightButton.interactable = status;
            leftButton.interactable = status;
        }
        #endregion
    }
}