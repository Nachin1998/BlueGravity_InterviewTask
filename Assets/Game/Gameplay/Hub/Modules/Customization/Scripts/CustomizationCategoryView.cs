using System;

using UnityEngine;
using UnityEngine.UI;

public class CustomizationCategoryView : MonoBehaviour
{
    [SerializeField] private Button rightButton = null;
    [SerializeField] private Button leftButton = null;

    public void Init(string id, Action<string> onLeftPressed, Action<string> onRightPressed)
    {
        rightButton.onClick.AddListener(() => onRightPressed?.Invoke(id));
        leftButton.onClick.AddListener(() => onLeftPressed?.Invoke(id));
    }
}
