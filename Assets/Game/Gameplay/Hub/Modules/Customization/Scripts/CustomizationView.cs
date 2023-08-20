using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Items.Body;

namespace BlueGravity.Game.Hub.Modules.Customization
{
    public class CustomizationView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private Button closeButton = null;
        [SerializeField] private UICharacterView displayCharacterView = null;
        [SerializeField] private CustomizationCategoryView[] categoryViews = null;

        public void Init(List<CategorySO> categories, Action<string> onPreviousPressed, Action<string> onNextPressed)
        {
            for (int i = 0; i < categoryViews.Length; i++)
            {
                categoryViews[i].Init(categories[i].Id, onPreviousPressed, onNextPressed);
            }

            closeButton.onClick.AddListener(() => Toggle(false));
        }

        public void Configure(List<BodyPartItemSO> parts)
        {
            displayCharacterView.SetParts(parts);

            Toggle(true);
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
        }

        public void ConfigureDisplayCharacter(int index, Sprite itemSprite)
        {
            displayCharacterView[index] = itemSprite;
        }
    }
}