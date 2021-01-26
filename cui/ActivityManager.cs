using System;
using System.Collections;
using System.Collections.Generic;
using tmlpaks.commons.cui;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons.ui
{
    public abstract class UIActivityBehaviour : MonoBehaviour
    {
        public abstract string GetID();
        public void Show()
        {
            Debug.Log($"[ACTIVITY:{gameObject.name}] Show");
            gameObject.SetActive(true);
            OnShow();
        }

        protected virtual void OnShow()
        {

        }

        public void Hide()
        {
            Debug.Log($"[ACTIVITY:{gameObject.name}] Hide");
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnHide()
        {

        }
    }
    public class ActivityManager : MonoBehaviour
    {
        public UIActivityBehaviour[] activities;

        public void Show(string activityID)
        {
            foreach (var a in activities)
            {
                if (a.GetID() == activityID)
                    a.Show();
                else if (a.isActiveAndEnabled)
                    a.Hide();
            }
        }
    }
}