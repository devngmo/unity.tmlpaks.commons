using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons
{
    public class ConsoleDebugger : Singleton<ConsoleDebugger>
    {
        public Text txtConsole;
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
            }
        }

        private void Update()
        {
            if (txtConsole != null)
            {
                txtConsole.text = _text;
            }
        }

        public void Clear()
        {
            Text = "";
        }

        public void Append(string msg)
        {
            _text += msg;
        }

        public void AppendNewLine(string msg)
        {
            _text += "\r\n" + msg;
        }
    }
}
