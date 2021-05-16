using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons
{
    public class ContentProcessorComponent : MonoBehaviour
    {
        public virtual string ProcessText(string input, object[] args = null)
        {
            return input;
        }

        public virtual string ProcessText(string input, object args = null)
        {
            return input;
        }
    }
}
