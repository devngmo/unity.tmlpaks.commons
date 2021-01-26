using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons
{
    public class LocalizationManagement
    {
        Dictionary<string, string> textMap = new Dictionary<string, string>();
        public LocalizationManagement()
        {

        }

        public void Load(string appCode, string language)
        {
            TextAsset ta = Resources.Load<TextAsset>($"{appCode}/Localization/{language}");
            foreach(string line in ta.text.Split())
            {
                int idx = line.IndexOf(':');
                if (idx > 0)
                {
                    string code = line.Substring(0, idx).Trim();
                    string mean = line.Substring(idx + 1).Trim();
                }
            }
        }

        public string Get(string code)
        {
            if (textMap.ContainsKey(code)) return textMap[code];
            return code;
        }
    }
}