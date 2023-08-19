using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Transform holder = null;
    [SerializeField] private ShopItemView itemViewPrefab = null;
    [SerializeField] private Transform itemsHolder = null;
    [SerializeField] private Button closePanelButton = null;

    private ObjectPool<ShopItemView> shopItemsPool = null;
    private List<ShopItemView> activeItems = null;

    private Action<ShopItemView> OnItemPressed = null;
    private Action OnPanelClosed = null;

    public void Init(Action<ShopItemView> onItemPressed, Action onPanelClosed)
    {
        shopItemsPool = new ObjectPool<ShopItemView>(GenerateItem, GetItem, ReleaseItem);
        activeItems = new List<ShopItemView>();

        OnItemPressed = onItemPressed;
        OnPanelClosed = onPanelClosed;
        closePanelButton.onClick.AddListener(ClosePanel);
    }

    public void Toggle(bool status)
    {
        holder.gameObject.SetActive(status);
    }

    public void Configure(List<ShopItemSO> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            ShopItemView view = shopItemsPool.Get();
            view.Configure(items[i]);
            activeItems.Add(view);
        }
    }

    public void ClosePanel()
    {
        for (int i = 0; i < activeItems.Count; i++)
        {
            shopItemsPool.Release(activeItems[i]);
        }

        shopItemsPool.Clear();

        Toggle(false);
        OnPanelClosed?.Invoke();
    }

    private ShopItemView GenerateItem()
    {
        ShopItemView item = Instantiate(itemViewPrefab, itemsHolder);
        item.Init(OnItemPressed);
        return item;
    }

    private void GetItem(ShopItemView item)
    {
        item.Toggle(true);
    }

    private void ReleaseItem(ShopItemView item)
    {
        item.Toggle(false);
    }
}