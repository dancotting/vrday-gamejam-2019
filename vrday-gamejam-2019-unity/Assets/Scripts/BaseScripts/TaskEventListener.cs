using UnityEngine;
using UnityEngine.Events;

public class TaskEventListener : MonoBehaviour
{
    public TaskEvent taskEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        taskEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        taskEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
