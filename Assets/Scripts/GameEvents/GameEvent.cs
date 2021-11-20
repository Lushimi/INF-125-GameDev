using System;
using System.Collections.Generic;
using UnityEngine;

//only functions when used with GameEventListener
//this is a scriptable object, it cannot be attached to a gameobject

[CreateAssetMenu] // lets you create game event from right-click context menu in unity
public class GameEvent : ScriptableObject 
{
    [SerializeField]
    private List<GameEventListener> listeners = new List<GameEventListener>(); // list of all GameEventListeners that will subscribe to the event

    public void Raise() // invoke all subscribers of game event
    {
        for (int i = listeners.Count - 1; i >= 0; i--) // iterates backwards so that the last listener that subscribed will be the first out
        {
            listeners[i].OnEventRaised(); // invokes each GameEventListener's UnityEvent
        }
    }

    public void RegisterListener(GameEventListener listener) // allows GameEventListeners to subscribe to this event
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) // allows GameEventListeners to unsubscribe from this event.
    {
        listeners.Remove(listener);
    }
}

//created following this tutorial
//https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started