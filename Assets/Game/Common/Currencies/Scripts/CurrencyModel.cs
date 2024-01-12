namespace BlueGravity.Common.Currencies
{
    public class CurrencyModel
    {
        #region PRIVATE_FIELDS
        private string id = string.Empty;
        private int value = 0;
        #endregion

        #region PROPERTIES
        public string Id { get => id; }
        public int Value { get => value; set => this.value = value; }
        #endregion

        #region CONSTRUCTOR
        public CurrencyModel(string id, int value) 
        {
            this.id = id;
            this.value = value;
        }
        #endregion
    }
}