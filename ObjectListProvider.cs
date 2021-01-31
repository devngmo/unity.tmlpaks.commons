using Assets.tmlpaks.commons.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.tmlpaks.commons
{
    public class ObjectListProvider: MonoBehaviour
    {
        [HideInspectorDerived()]
        public MonoBehaviour[] items;
        public virtual int Count => items.Length;
        public virtual object GetAt(int index)
        {
            return items[index];
        }
    }
}
