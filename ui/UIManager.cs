using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons.ui
{
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<string, RectTransform> dialogMap = new Dictionary<string, RectTransform>();

        public void addDialog(string dialogID, RectTransform dialogTransform)
        {
            if (dialogMap.ContainsKey(dialogID))
                dialogMap[dialogID] = dialogTransform;
            else
                dialogMap.Add(dialogID, dialogTransform);
        }
        public void showDialog(string dialogID)
        {
            dialogMap[dialogID].gameObject.SetActive(true);
        }


    }
}