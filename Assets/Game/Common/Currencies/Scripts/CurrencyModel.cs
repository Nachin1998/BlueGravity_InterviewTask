using UnityEngine;

namespace BlueGravity.Common.Currencies
{
    [System.Serializable]
    public class CurrencyModel
    {
        [SerializeField] private string id = string.Empty;
        [SerializeField] private int value = 0;

        public string Id { get => id; }
        public int Value { get => value; set => this.value = value; }

        public CurrencyModel(string id, int value) 
        {
            this.id = id;
            this.value = value;
        }
    }
}