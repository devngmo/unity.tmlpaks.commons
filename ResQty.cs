using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons
{
    public class ResQty
    {
        public string ID;
        public float Quantity;
        public int QuantityInt => (int)Quantity;
    }

    public class ResQtyValue : ResQty
    {
        float _Value;
        public float Value
        {
            get => _Value;
            set
            {
                _Value = Mathf.Clamp(value + _Value, 0, Quantity);
            }
        }
        public int ValueInt => (int)Value;
    }
}