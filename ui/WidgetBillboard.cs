using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.ui
{
    public class WidgetBillboard : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}