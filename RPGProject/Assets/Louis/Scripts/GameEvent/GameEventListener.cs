using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent gameEventCallback;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnGameEventRaised()
    {
        gameEventCallback.Invoke();
    }
}
