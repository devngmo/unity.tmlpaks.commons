using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmlpaks.commons
{
    [Serializable]
    public class IntRange
    {
        public int Min;
        public int Max;
        public int Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }
    }
}
