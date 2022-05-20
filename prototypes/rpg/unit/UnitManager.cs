using System.Collections;
using System.Collections.Generic;
using tmlpaks.commons;
using UnityEngine;

namespace tmlpaks.prototypes.rpg.unit
{
    public class UnitManager : Singleton<UnitManager>
    {
        public Transform deadPool;
        public Transform livePool;

        public List<Transform> getUnitsBylayerMask(LayerMask mask)
        {
            List<Transform> found = new List<Transform> ();
            for (int i = 0; i < livePool.childCount; i++)
            {
                Transform child = livePool.GetChild(i);
                if ((child.gameObject.layer & mask) == child.gameObject.layer)
                {
                    found.Add(child);
                }
            }
            return found;
        }
    }
}