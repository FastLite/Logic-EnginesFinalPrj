using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsController : MonoBehaviour
{


    public string eventName;
    public string key;
    public string value;

    AnalyticsManager am;


   public void recordEvent()
    {
        AnalyticsManager.instance.recordEvent(eventName);
    }

    public void recordEventDictionary()
    {
        AnalyticsManager.instance.recordEvent(eventName, key, value);
    }

    
}
