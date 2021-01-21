using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T s_ins;
        static bool m_ShuttingDown = false;
        private static object m_Lock = new object();
        public static T Ins
        {
            get
            {
                if (m_ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed. Returning null.");
                    return null;
                }

                lock (m_Lock)
                {
                    if (s_ins == null)
                    {
                        // Search for existing instance.
                        s_ins = (T)FindObjectOfType(typeof(T));

                        // Create new instance if one doesn't already exist.
                        if (s_ins == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            s_ins = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return s_ins;
                }
            }
        }


        private void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }


        private void OnDestroy()
        {
            m_ShuttingDown = true;
        }
    }
}