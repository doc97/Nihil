using System;
using System.Collections.Generic;

public static class UIMessages
{
    private static Dictionary<UIMessage, List<Action<UIMessage, object>>> listeners;

    static UIMessages()
    {
        listeners = new Dictionary<UIMessage, List<Action<UIMessage, object>>>();
    }

    public static void Notify(UIMessage message, object data)
    {
        foreach (Action<UIMessage, object> listener in listeners[message])
            listener.Invoke(message, data);
    }

    public static void Subscribe(UIMessage message, Action<UIMessage, object> listener)
    {
        if (!listeners.ContainsKey(message))
            listeners[message] = new List<Action<UIMessage, object>>();
        listeners[message].Add(listener);
    }

    public static void Unsubscribe(UIMessage message, Action<UIMessage, object> listener)
    {
        if (!listeners.ContainsKey(message))
            return;
        listeners[message].Remove(listener);
        if (listeners[message].Count == 0)
            listeners.Remove(message);
    }
}