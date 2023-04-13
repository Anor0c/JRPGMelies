using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent/BaseEvent", order = 0)]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners= new List<GameEventListener>();

    public void AddListener(GameEventListener _listener)
    {
        listeners.Add(_listener);
    }
    public void RemoveListener(GameEventListener _listener)
    {
        listeners.Remove(_listener);
    }
    public void Raised()
    {
        foreach(var _listener in listeners)
        {
            _listener.OnGameEventRaised();
        }
    }
}
