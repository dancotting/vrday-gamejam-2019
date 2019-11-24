using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour
{
    public RoomEvent addNewTaskEvent;
    public List<Task> activeTasks = new List<Task>();

    //public void AddNewTask()
    //{
    //    addNewTaskEvent.Raise();
    //}

    public void AddTaskToActive(Task task)
    {
        activeTasks.Add(task);
    }



    public enum RoomMood
    {
        patient,
        annoyed,
        irate
    }
}
