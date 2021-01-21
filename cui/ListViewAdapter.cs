using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.cui
{
    public interface ListViewContentProvider
    {
        int Count { get; }

        object GetItemAt(int index);
    }
    public class ListViewAdapter : MonoBehaviour
    {
        public ListViewItemHolder itemViewTemplate;
        public RectTransform viewportContent;
        public float itemSpacing = 2;

        ListViewContentProvider _contentProvider;
        [HideInInspector]
        public ListViewContentProvider Provider
        {
            get => _contentProvider;
            set
            {
                _contentProvider = value;
                NotifyDataChanged();
            }
        }

        private List<ListViewItemHolder> items = new List<ListViewItemHolder>();

        void Start()
        {
            
        }

        internal void NotifyDataChanged()
        {
            foreach (ListViewItemHolder item in items)
            {
                GameObject.Destroy(item.gameObject);
            }
            items.Clear();
            if (Provider == null) return;

            
            float top = -itemSpacing;
            for (int i = 0; i < Provider.Count; i++)
            {
                ListViewItemHolder newItem = GameObject.Instantiate(itemViewTemplate);
                RectTransform newItemRT = newItem.GetComponent<RectTransform>();
                newItemRT.parent = viewportContent;
                float itemH = newItem.GetComponent<RectTransform>().rect.height;
                top -= itemH/2 + itemSpacing;
                newItemRT.position = new Vector3(newItemRT.position.x, top);
                newItem.Bind(Provider.GetItemAt(i));
                items.Add(newItem);
                top -= itemH/2 + itemSpacing;
            }
        }

        void Update()
        {

        }
    }
}