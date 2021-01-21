using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.cui
{
    public interface DialogListener
    {
        bool OnEvent(MessageDialog dialog, string eventID);
    }
}