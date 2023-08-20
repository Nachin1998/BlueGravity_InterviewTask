using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Items.Body;
using BlueGravity.Common.Player;

namespace BlueGravity.Game.Hub.Modules.Customization
{
    public class CustomizationController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private CustomizationView view = null;
        [SerializeField] private FashionDesignerView fashionDesignerView = null;
        [SerializeField] private List<CategorySO> categories = null;

        private PlayerController player = null;

        private Dictionary<CategorySO, int> currentCategoryIndexes = null;

        public void Init()
        {
            currentCategoryIndexes = new Dictionary<CategorySO, int>();

            for (int i = 0; i < categories.Count; i++)
            {
                currentCategoryIndexes.Add(categories[i], 0);
            }

            view.Init(categories, ConfigurePreviousItem, ConfigureNextItem);

            fashionDesignerView.Init(
                onInteracted: () =>
                {
                    view.Configure(player.CurrentParts);
                },
                onCustomerInRange: (customer) =>
                {
                    if (customer.TryGetComponent(out PlayerController player))
                    {
                        SetCharacter(player);
                    }
                },
                onCustomerLeave: () =>
                {
                    SetCharacter(null);
                    view.Toggle(false);
                });
        }

        private void SetCharacter(PlayerController player)
        {
            this.player = player;
        }

        private void ConfigureNextItem(string categoryId)
        {
            CategorySO category = GetCategory(categoryId);
            int index = currentCategoryIndexes[category];
            index++;

            if (index >= category.UnlockedItems.Count)
            {
                index = 0;
            }

            currentCategoryIndexes[category] = index;

            BodyPartItemSO item = category.UnlockedItems[index];

            ConfigureItem(categories.IndexOf(category), item);
        }

        private void ConfigurePreviousItem(string categoryId)
        {
            CategorySO category = GetCategory(categoryId);
            int index = currentCategoryIndexes[category];
            index--;

            if (index < 0)
            {
                index = category.UnlockedItems.Count - 1;
            }

            currentCategoryIndexes[category] = index;

            BodyPartItemSO item = category.UnlockedItems[index];

            ConfigureItem(categories.IndexOf(category), item);
        }

        private void ConfigureItem(int index, BodyPartItemSO item)
        {
            view.ConfigureDisplayCharacter(index, item.Icon);
            player.SetPart(item);
        }

        private CategorySO GetCategory(string id)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Id == id)
                {
                    return categories[i];
                }
            }

            Debug.Log("Category of id " + id + " was not found");
            return null;
        }
    }
}