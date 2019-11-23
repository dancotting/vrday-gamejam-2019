using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new List<Room>();
    public List<TaskEvent> events = new List<TaskEvent>();

    public void AddRoomTask(Room thisRoom)
    {

    }

    public void FireOffNextEvent()
    {
        if(events.Count>0)
        {
            var tmpEvent = events.FirstOrDefault();
            events.RemoveAt(0);
            tmpEvent.room.AddTaskToCurrent(tmpEvent.task);
        }
    }
}
