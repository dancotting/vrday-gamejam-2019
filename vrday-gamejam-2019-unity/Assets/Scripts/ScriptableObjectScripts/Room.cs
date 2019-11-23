using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Room", menuName = "BoatLuv/CreateNewRoom", order = 1)]
public class Room : ScriptableObject
{
    public RoomMood currentMood;
    public string roomName;
    public List<Task> availableTasks = new List<Task>();
    private List<Task> currentTasks = new List<Task>();

    public void AddTaskToCurrent(Task thisTask)
    {
        currentTasks.Add(thisTask);
    }    

    public enum RoomMood
    {
        patient,
        annoyed,
        irate
    }

}
