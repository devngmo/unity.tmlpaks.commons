using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmlpaks.commons
{
    [Serializable]
    public class MinMax
    {
        public float Min;
        public float Max;
        public int MinInt
        {
            get => (int)Min;
        }
        public int MaxInt
        {
            get => (int)Max;
        }

        public float randomAdd(float addition = 0)
        {
            return UnityEngine.Random.Range(Min, Max) + addition;
        }
        public float random()
        {
            return randomAdd(0);
        }

        public float randomInt()
        {
            return (int)randomAdd(0);
        }
    }
}
