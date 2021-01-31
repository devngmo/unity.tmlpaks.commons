using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons
{
    public class NameFactory
    {
        List<string> nameList = new List<string>();
        public NameFactory()
        {

        }

        public void Load(string id)
        {
            nameList.Clear();
            TextAsset ta = Resources.Load<TextAsset>($"{id}");
            foreach(string line in ta.text.Split())
            {
                string name = line.Trim();
                if (name.Length > 1)
                {
                    nameList.Add(name);
                }
            }
            Debug.Log($"Name Factory: loaded {nameList.Count} names");
        }

        public string Random()
        {
            int idx = UnityEngine.Random.Range(0, nameList.Count);
            return nameList[idx];
        }
    }
}