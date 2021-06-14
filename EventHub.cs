using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.tmlpaks.commons
{
    public interface EventHubListener
    {
        void onHubEvent(string eventID, object data = null);
    }
    public static class EventHub
    {
        static List<EventHubListener> listenerMap = new List<EventHubListener>();

        public static void register(EventHubListener lis)
        {
            if (listenerMap.Contains(lis))
                return;
            listenerMap.Add(lis);
        }

        public static void unregister(EventHubListener lis)
        {
            if (!listenerMap.Contains(lis))
                return;
            listenerMap.Remove(lis);
        }

        public static void post(string eventID, object data = null)
        {
            foreach (EventHubListener lis in listenerMap)
            {
                try
                {
                    lis.onHubEvent(eventID, data);
                }
                catch(Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
            }
        }
    }
}
