using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationView : MonoBehaviour
{
    [SerializeField] private Transform holder = null;
    [SerializeField] private Button applyButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private UICharacterView displayCharacterView = null;
    [SerializeField] private CustomizationCategoryView[] categoryViews = null;

    private SpriteCharacterView currentCharacterView = null;

    public void Init(List<CategorySO> categories, Action<string> onPreviousPressed, Action<string> onNextPressed)
    {
        for (int i = 0; i < categoryViews.Length; i++)
        {
            categoryViews[i].Init(categories[i].Id, onPreviousPressed, onNextPressed);
        }

        applyButton.onClick.AddListener(ApplyChanges);
        closeButton.onClick.AddListener(() => Toggle(false));
    }

    public void Configure(SpriteCharacterView character)
    {
        currentCharacterView = character;
        displayCharacterView.CopyBody(character);

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

    private void ApplyChanges()
    {
        currentCharacterView.CopyBody(displayCharacterView);
        Toggle(false);
    }
}
