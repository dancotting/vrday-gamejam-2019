using UnityEngine;
using UnityEngine.Events;

public class RoomEventListener : MonoBehaviour
{
    public RoomEvent roomEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        roomEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        roomEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
