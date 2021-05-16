using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons
{
    public static class RectTransformExtensions
    {
        public static RectTransform Left(this RectTransform rt, float x)
        {
            rt.offsetMin = new Vector2(x, rt.offsetMin.y);
            return rt;
        }

        public static RectTransform Right(this RectTransform rt, float x)
        {
            rt.offsetMax = new Vector2(-x, rt.offsetMax.y);
            return rt;
        }

        public static RectTransform Bottom(this RectTransform rt, float y)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, y);
            return rt;
        }

        public static RectTransform Top(this RectTransform rt, float y)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -y);
            return rt;
        }

        public static void DockFillAndUseParentSize(this RectTransform _mRect, RectTransform _parent)
        {
            _mRect.offsetMin = new Vector2();
            _mRect.offsetMax = new Vector2();
            _mRect.sizeDelta = new Vector2(_parent.rect.width, _parent.rect.height);
            _mRect.anchoredPosition = _parent.position;
            _mRect.anchorMin = new Vector2(0, 0);
            _mRect.anchorMax = new Vector2(1, 1);
            _mRect.pivot = new Vector2(0.5f, 0.5f);
            _mRect.transform.SetParent(_parent);
            _mRect.offsetMin = new Vector2();
            _mRect.offsetMax = new Vector2();
        }
        public static void DockFillParent(this RectTransform _mRect)
        {
            _mRect.offsetMin = new Vector2();
            _mRect.offsetMax = new Vector2();
            _mRect.anchorMin = new Vector2(0, 0);
            _mRect.anchorMax = new Vector2(1, 1);
        }
        public static void DockFill(this RectTransform _mRect, RectTransform _parent)
        {
            _mRect.offsetMin = new Vector2();
            _mRect.offsetMax = new Vector2();
            _mRect.anchoredPosition = _parent.position;
            _mRect.anchorMin = new Vector2(0, 0);
            _mRect.anchorMax = new Vector2(1, 1);
            _mRect.pivot = new Vector2(0.5f, 0.5f);
            _mRect.transform.SetParent(_parent);
            _mRect.offsetMin = new Vector2();
            _mRect.offsetMax = new Vector2();
        }

        internal static RectTransform Create(string name)
        {
            GameObject go = new GameObject(name, typeof(RectTransform));
            return go.GetComponent<RectTransform>();
        }

        internal static Text CreateText(string name)
        {
            GameObject go = new GameObject(name, typeof(Text));
            return go.GetComponent<Text>();
        }

        internal static Text CreateScrollView(string name)
        {
            GameObject go = new GameObject(name, typeof(Text));
            return go.GetComponent<Text>();
        }
    }
}
