using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmlpaks.commons
{
    [Serializable]
    public class ValueMax
    {
        private float _Value;
        public float Max;
        public float Value
        {
            get => _Value;
            set
            {
                _Value = value;
                if (_Value < 0) _Value = 0;
                if (_Value > Max) _Value = Max;
            }
        }
        public int ValueInt
        {
            get => (int)_Value;
        }
        public int MaxInt
        {
            get => (int)Max;
        }

        internal void Set(int value)
        {
            _Value = Max = value;
        }

        public ValueMax()
        {

        }
        public ValueMax(float initValue)
        {
            Value = initValue;
            Max = initValue;
        }

        public void Adjust(float amount)
        {
            Value += amount;
        }
    }
}
