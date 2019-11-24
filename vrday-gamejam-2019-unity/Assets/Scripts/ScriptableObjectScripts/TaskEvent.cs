using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Task_Event", menuName = "BoatLuv/CreateNewTaskEvent", order = 1)]
public class TaskEvent : ScriptableObject
{
    private List<TaskEventListener> taskEventListeners = new List<TaskEventListener>();

    public void Raise()
    {
        for (int i = taskEventListeners.Count - 1; i >= 0; i--)
        {
            taskEventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(TaskEventListener listener)
    {
        taskEventListeners.Add(listener);
    }

    public void UnregisterListener(TaskEventListener listener)
    {
        taskEventListeners.Remove(listener);
    }
}
