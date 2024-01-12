using System;

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
        [SerializeField] private Transform holder = null;
        [SerializeField] private Transform categoriesHolder = null;
        [SerializeField] private CustomizationCategoryView categoryViewPrefab = null;
        [SerializeField] private UICharacterView displayPlayer = null;
        [SerializeField] private Button closeButton = null;

        public event Action<bool> OnPanelToggled = null;

        public void Init()
        {
            closeButton.onClick.AddListener(ClosePanel);
        }

        public void AddCategory(string id, Action<string> onLeftPressed, Action<string> onRightPressed)
        {
            CustomizationCategoryView item = Instantiate(categoryViewPrefab, categoriesHolder);
            item.Init(id, onLeftPressed, onRightPressed);
        }

        public void ConfigurePlayer(PlayerView player)
        {
            displayPlayer.Copy(player);
        }

        private void ClosePanel()
        {
            Toggle(false);
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
    }
}