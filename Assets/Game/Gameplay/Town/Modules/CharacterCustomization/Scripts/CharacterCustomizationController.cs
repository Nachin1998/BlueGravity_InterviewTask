using System;
using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.NPC;
using BlueGravity.Common.Items.BodyParts;
using BlueGravity.Common.Interaction;
using BlueGravity.Common.Player;

namespace BlueGravity.Game.Town.Modules.CharacterCustomization
{
    public class CharacterCustomizationController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private CharacterCustomizationView view = null;
        [SerializeField] private NPCCharacterView fashonDesigner = null;
        [SerializeField] private InteractionArea fashonDesignerArea = null;
        #endregion

        #region PRIVATE_FIELDS
        private Dictionary<string, List<BodyPartItemSO>> categoryItemsDic = null;
        private Dictionary<string, int> categoryIndexes = null;
        private PlayerView player = null;
        #endregion

        #region CONSTANTS
        private const int minimumItemsAmount = 1;
        #endregion

        #region ACTIONS
        public event Action<bool> OnPanelToggled = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init()
        {
            fashonDesigner.OnInteracted += () => ToggleView(true);
            fashonDesignerArea.OnTriggerEnter += TryGetPlayer;
            fashonDesignerArea.OnTriggerExit += TryRemovePlayer;

            view.OnPanelToggled += OnPanelToggled;

            view.Init();
            for (int i = 0; i < (int)BODY_PART.MAX; i++)
            {
                BODY_PART currentPart = (BODY_PART)i;
                string id = currentPart.ToString();
                view.AddCategory(id, ConfigurePreviousItem, ConfigureNextItem);
            }
        }

        public void RefreshItems(List<BodyPartItemSO> items)
        {
            categoryItemsDic = new Dictionary<string, List<BodyPartItemSO>>();
            categoryIndexes = new Dictionary<string, int>();

            for (int i = 0; i < (int)BODY_PART.MAX; i++)
            {
                BODY_PART currentPart = (BODY_PART)i;
                List<BodyPartItemSO> categoryItems = items.FindAll((item) => item.Part == currentPart);

                string id = currentPart.ToString();
                categoryItemsDic.Add(id, categoryItems);
                categoryIndexes.Add(id, 0);
                view.GetView(id).ToggleInteractability(categoryItemsDic[id].Count > minimumItemsAmount);
            }
        }
        #endregion

        #region PRIVATE_METHODS
        private void ConfigureNextItem(string id)
        {
            if (!categoryItemsDic.ContainsKey(id))
            {
                return;
            }

            int index = categoryIndexes[id];
            index++;

            if (index >= categoryItemsDic[id].Count)
            {
                index = 0;
            }

            categoryIndexes[id] = index;

            BodyPartItemSO item = categoryItemsDic[id][index];
            ConfigureItem(item);
        }

        private void ConfigurePreviousItem(string id)
        {
            if (!categoryItemsDic.ContainsKey(id))
            {
                return;
            }

            int index = categoryIndexes[id];
            index--;

            if (index < 0)
            {
                index = categoryItemsDic[id].Count - 1;
            }

            categoryIndexes[id] = index;

            BodyPartItemSO item = categoryItemsDic[id][index];
            ConfigureItem(item);
        }

        private void ToggleView(bool status)
        {
            if (status)
            {
                view.ConfigurePlayer(player);
                ConfigureIndexes(player);
            }

            view.Toggle(status);
        }

        private void ConfigureIndexes(PlayerView player)
        {
            for (int i = 0; i < player.BodyParts.Count; i++)
            {
                BodyPartItemSO item = player.BodyParts[i];
                string id = item.Part.ToString();
                categoryIndexes[id] = categoryItemsDic[id].Contains(item) ? categoryItemsDic[id].IndexOf(item) : categoryIndexes[id];
            }
        }

        private void ConfigureItem(BodyPartItemSO item)
        {
            player.SetBodyPart(item);
            view.ConfigureItem(item);
        }

        private void TryGetPlayer(GameObject obj)
        {
            if (obj.TryGetComponent(out PlayerView player))
            {
                this.player = player;
            }
        }

        private void TryRemovePlayer(GameObject obj)
        {
            if (obj.TryGetComponent(out PlayerView _))
            {
                player = null;
            }
        }
        #endregion
    }
}