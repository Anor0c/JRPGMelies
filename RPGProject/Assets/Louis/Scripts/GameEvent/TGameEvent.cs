using System.Collections.Generic;
using UnityEngine;

public class TGameEvent<T> : ScriptableObject
{
    public List<TGameEventListener<T>> listeners = new List<TGameEventListener<T>>();
    public void AddListener(TGameEventListener<T> _listener)
    {
        listeners.Add(_listener);
    }
    public void RemoveListener(TGameEventListener<T> _listener)
    {
        listeners.Remove(_listener);
    }
    public void Raised(T _value)
    {
        foreach (var _listener in listeners)
        {
            _listener.OnGameEventRaised(_value);
        }
    }
}
