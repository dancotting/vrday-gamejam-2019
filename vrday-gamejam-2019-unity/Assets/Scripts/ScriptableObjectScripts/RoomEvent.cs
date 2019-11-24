using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Room_Event", menuName = "BoatLuv/CreateNewRoomEvent", order = 3)]
public class RoomEvent : ScriptableObject
{
    private List<RoomEventListener> taskEventListeners = new List<RoomEventListener>();

    public void Raise()
    {
        for (int i = taskEventListeners.Count - 1; i >= 0; i--)
        {
            taskEventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(RoomEventListener listener)
    {
        taskEventListeners.Add(listener);
    }

    public void UnregisterListener(RoomEventListener listener)
    {
        taskEventListeners.Remove(listener);
    }
}
