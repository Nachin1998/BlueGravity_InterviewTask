using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Items.BodyParts;

using BlueGravity.Game.Hub.Modules.Customization;
using BlueGravity.Common.Player;

namespace BlueGravity.Game.Town.Modules.CharacterCustomization
{
    public class CharacterCustomizationView : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private Transform categoriesHolder = null;
        [SerializeField] private CustomizationCategoryView categoryViewPrefab = null;
        [SerializeField] private UICharacterView displayPlayer = null;
        [SerializeField] private Button closeButton = null;
        #endregion

        #region ACTIONS
        public event Action<bool> OnPanelToggled = null;
        #endregion

        #region PRIVATE_FIELDS
        private List<CustomizationCategoryView> views = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init()
        {
            views = new List<CustomizationCategoryView>();
            closeButton.onClick.AddListener(ClosePanel);
        }

        public void AddCategory(string id, Action<string> onLeftPressed, Action<string> onRightPressed)
        {
            CustomizationCategoryView item = Instantiate(categoryViewPrefab, categoriesHolder);
            item.Init(id, onLeftPressed, onRightPressed);
            views.Add(item);
        }

        public CustomizationCategoryView GetView(string id)
        {
            CustomizationCategoryView view = views.Find((item) => item.Id == id);

            if (view == null)
            {
                Debug.LogError("Failed to find view of id " + id);
            }

            return view;
        }

        public void ConfigurePlayer(PlayerView player)
        {
            displayPlayer.Copy(player);
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
            OnPanelToggled?.Invoke(status);
        }

        public void ConfigureItem(BodyPartItemSO item)
        {
            displayPlayer.SetBodyPart(item);
        }
        #endregion

        #region PRIVATE_METHODS
        private void ClosePanel()
        {
            Toggle(false);
        }
        #endregion
    }
}