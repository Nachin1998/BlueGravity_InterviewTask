using UnityEngine;
using UnityEngine.UI;

public class CustomizationView : MonoBehaviour
{
    [SerializeField] private Button applyButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private UICharacterView characterView = null;
    [SerializeField] private CustomizationCategoryView[] categories = null;

    public void Init()
    {

    }
}
