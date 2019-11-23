using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Room", menuName = "BoatLuv/CreateNewRoom", order = 1)]
public class Room : ScriptableObject
{
    public string roomName;
    public List<Task> availableTasks = new List<Task>();
    private List<Task> currentTasks = new List<Task>();
    private float roomMoodCalculation = 0;
    public float roomMoodCalculationMax = 100;

    public void AddTaskToCurrent(Task thisTask)
    {
        currentTasks.Add(thisTask);
    }    

    public RoomMood currentMood
    {
        get
        {
            var moodPercent = roomMoodCalculation / roomMoodCalculationMax;
            if(moodPercent>.66)
            {
                return RoomMood.irate;
            }
            if (moodPercent > .33)
            {
                return RoomMood.annoyed;
            }
            return RoomMood.patient;
        }

    }
    
    public enum RoomMood
    {
        patient,
        annoyed,
        irate
    }

}
