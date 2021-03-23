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
            Debug.Log($"{gameObject.name} NotifyDataChanged");
            foreach (ListViewItemHolder item in items)
            {
                GameObject.Destroy(item.gameObject);
            }
            items.Clear();
            if (Provider == null) return;

            float contentH = itemSpacing;
            float top = itemSpacing;
            for (int i = 0; i < Provider.Count; i++)
            {
                ListViewItemHolder newItem = GameObject.Instantiate(itemViewTemplate);
                RectTransform newItemRT = newItem.GetComponent<RectTransform>();
                newItemRT.SetParent(viewportContent);
                Vector2 sz = newItemRT.sizeDelta;
                float itemH = sz.y;
                top += itemH / 2 + itemSpacing;
                //newItemRT.anchoredPosition = new Vector2(0, -top);
                newItemRT.Left(0).Right(0).Top(top).Bottom(top - itemH);
                newItemRT.sizeDelta = sz;

                newItem.Bind(Provider.GetItemAt(i));
                items.Add(newItem);
                top += itemH/2 + itemSpacing;

                contentH += itemH + itemSpacing;
                Debug.Log($"item [{i}] at {newItemRT.rect}");
            }

            viewportContent.sizeDelta = new Vector2(viewportContent.sizeDelta.x, contentH);
        }

        void Update()
        {

        }
    }
}