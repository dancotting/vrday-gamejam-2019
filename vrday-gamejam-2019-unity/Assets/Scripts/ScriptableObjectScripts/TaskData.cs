using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Task_Data", menuName = "BoatLuv/CreateNewTaskData", order = 0)]
public class TaskData : ScriptableObject
{
    public int taskIndex;
    public string taskName;
    public string taskDescription;
    public TaskDifficulty taskDifficulty;
    public int roomIndex;

    //public List<RoomSpecificTaskData> roomSpecificData = new List<RoomSpecificTaskData>();
    [Header("Room Specific Audio Clips")]
    public RoomSpecificAudio barAudio;
    public RoomSpecificAudio poolAudio;
    public RoomSpecificAudio vipAudio;
    public RoomSpecificAudio bedroomAudio;
    public RoomSpecificAudio engineRoomAudio;
    public RoomSpecificAudio casinoAudio; 
}

public enum TaskDifficulty
{
    Easy,
    Medium,
    Hard,
    Insane
}
