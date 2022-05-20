using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.prototypes.rpg.unit
{
    public class UnitAI : MonoBehaviour
    {
        public LayerMask targetMask;
        public ChasingBehaviour chasing;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (chasing != null)
            {
                if (chasing.target == null)
                {
                    List<Transform> targets = UnitManager.Ins.getUnitsBylayerMask(targetMask);
                    if (targets.Count > 0)
                    {
                        chasing.target = targets[0];
                    }
                }
            }
        }
    }
}