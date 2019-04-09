using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage custom events.
/// </summary>
public class EventManager : Singleton<EventManager> {

    public static string EVENT_STEP_START = "EVENT_STEP_START";
    public static string EVENT_STEP_END = "EVENT_STEP_END";
    public static string EVENT_STEP_PROCESS = "EVENT_STEP_PROCESS";
    public static string EVENT_STEP_INCOMPLETE = "EVENT_STEP_INCOMPLETE";
    public static string EVENT_STOP_GLOW = "EVENT_STOP_GLOW";
    public static string EVENT_START_GLOW = "EVENT_START_GLOW";

    public static string EVENT_EACH_STEP_START = "EVENT_EACH_STEP_START_";
    public static string EVENT_EACH_STEP_END = "EVENT_EACH_STEP_END_";
    /// <summary>
    /// Event call back delegate
    /// </summary>
    public delegate void NotificationAction();

    /// <summary>
    /// Store events which are sent to other systems
    /// </summary>
    private Dictionary<string, NotificationAction> notificationDic = new Dictionary<string, NotificationAction>();

    /// <summary>
    /// reset eventDic
    /// </summary>
    public void Reset()
    {
    }

    /// <summary>
    /// Register event call back
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="onNotificationHandler">function that handle this event</param>
    public void AddEventHandler(string eventName, NotificationAction onNotificationHandler)
    {
        //Debug.Log("RegisterNotification : " + eventName);
        //UnRegisterNotification(eventName, null);
        if (!notificationDic.ContainsKey(eventName))
        {
            notificationDic.Add(eventName, onNotificationHandler);
        }
        else
        {
            notificationDic[eventName] -= onNotificationHandler;
            notificationDic[eventName] += onNotificationHandler;
        }
    }

    /// <summary>
    /// Unregister event after the game object is destroyed
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="onNotificationHandler"></param>
    public void RemoveEventHandler(string eventName, NotificationAction onNotificationHandler)
    {
        //notificationDic.Remove(eventName);
        if (notificationDic.ContainsKey(eventName))
        {
            notificationDic[eventName] -= onNotificationHandler;
            if (notificationDic[eventName] == null)
            {
                notificationDic.Remove(eventName);
            }
        }
    }

    /// <summary>
    /// Send notification to trigger call backs
    /// </summary>
    /// <param name="notificationName">event name</param>
    public void SendEvent(string notificationName)
    {
        if (notificationDic.ContainsKey(notificationName))
        {
            //Debug.Log("SendNotification : " + notificationName);
            NotificationAction onNotificationHandler = notificationDic[notificationName];
            onNotificationHandler();
        }
    }

    private void Update()
    {
        
    }

    private void Start()
    {
    }
}
