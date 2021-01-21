using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.cui
{
    public interface ListViewItemBinder
    {
        void Bind(object model);
    }
    public class ListViewItemHolder : MonoBehaviour
    {
        
        void Start()
        {

        }

        void Update()
        {

        }

        internal void Bind(object itemModel)
        {
            try
            {
                var binder = GetComponent<ListViewItemBinder>();
                binder.Bind(itemModel);
            }
            catch(Exception ex)
            {

            }
        }
    }
}