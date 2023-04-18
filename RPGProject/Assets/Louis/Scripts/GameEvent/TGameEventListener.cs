using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TGameEventListener<T> : MonoBehaviour
{
    public TGameEvent<T> gameEvent;
    public UnityEvent<T> gameEventCallback;
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnGameEventRaised(T _value)
    {
        gameEventCallback.Invoke(_value);
    }
}
