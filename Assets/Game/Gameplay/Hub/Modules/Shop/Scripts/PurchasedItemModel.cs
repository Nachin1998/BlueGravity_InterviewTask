[System.Serializable]
public class PurchasedItemModel
{
    private string itemId = string.Empty;
    private bool isPurchased = false;

    public string ItemId { get => itemId; }
    public bool IsPurchased { get => isPurchased; }

    public PurchasedItemModel(string itemId, bool isPurchased) 
    {
        this.itemId = itemId;
        this.isPurchased = isPurchased;
    }
}
