using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace tmlpaks.commons.cui
{
    public class DialogManager : MonoBehaviour
    {
        public MessageDialog MessageDialogTemplate;
        public RectTransform dialogContainer;

        public void ShowMessage(DialogListener listener, string title, string msg)
        {
            MessageDialog dlg = GameObject.Instantiate(MessageDialogTemplate);
            RectTransform rt = dlg.GetComponent<RectTransform>();
            rt.DockFillAndUseParentSize(dialogContainer);
            dlg.Show(listener, title, msg);
            rt.DockFillParent();
        }
    }
}
