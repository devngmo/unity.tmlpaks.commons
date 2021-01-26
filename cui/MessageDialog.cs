using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons.cui
{
    public class MessageDialog : MonoBehaviour
    {
        public const string EVT_OK = "ok";
        public const string EVT_CANCEL = "cancel";
        DialogListener Listener;

        public Text title, msg;

        public void Show(DialogListener listener, string title, string msg)
        {
            this.title.text = title;
            this.msg.text = msg;
            this.Listener = listener;
            gameObject.SetActive(true);
        }

        public void OnOK()
        {
            Listener.OnEvent(this, EVT_OK);
        }

        public void OnCancel()
        {
            Listener.OnEvent(this, EVT_CANCEL);
            Dismiss();
        }

        public void Dismiss()
        {
            GameObject.Destroy(gameObject);
        }
    }
}