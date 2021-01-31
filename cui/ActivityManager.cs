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

        List<string> navHistory = new List<string>();

        public string CurrentActivityID
        {
            get
            {
                if (navHistory.Count == 0) return null;
                return navHistory[navHistory.Count - 1];
            }
        }

        public string PreviousActivityID {
            get
            {
                if (navHistory.Count < 2) return null;
                return navHistory[navHistory.Count - 2];
            }
        }


        public bool Show(string activityID, bool removeThisFromHistory = true)
        {
            if (CurrentActivityID == activityID) return false;

            if (removeThisFromHistory)
                navHistory.Remove(activityID);

            navHistory.Add(activityID);

            foreach (var a in activities)
            {
                if (a.GetID() == activityID)
                    a.Show();
                else if (a.isActiveAndEnabled)
                    a.Hide();
            }
            return true;
        }

        internal void back()
        {
            if (PreviousActivityID != null)
            {
                Show(PreviousActivityID);
            }
        }

        internal T getActivity<T>(string activityID)
        {
            foreach (var a in activities)
            {
                if (a.GetID() == activityID)
                    return (T)((object)a);
            }
            return default(T);
        }

        internal void pushNavHistory(string activityID)
        {
            navHistory.Add(activityID);
        }
    }
}