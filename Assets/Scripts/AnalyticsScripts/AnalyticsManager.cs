using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class AnalyticsManager : MonoBehaviour
{


    public static AnalyticsManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    public void recordEvent(string eventname)
    {
        // player died 
        Analytics.CustomEvent(eventname);
    }

    public void recordEvent(string eventname, string key, string value)
    {
        // eventname = Level complete, key = snakeLevel, value = A
        // eventname = skinsPurchased, key = character, value = skin2
        Dictionary<string, object> eventParms = new Dictionary<string, object>();
        eventParms.Add(key, value);
        Analytics.CustomEvent(eventname, eventParms);

    }
}


