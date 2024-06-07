using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManagerScript : MonoBehaviour
{
    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public static void StartListening(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(string eventName)
    {
        //Debug.Log("Event triggered.");
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            //Debug.Log("EventSent triggered.");
            thisEvent?.Invoke();
        }
    }
}