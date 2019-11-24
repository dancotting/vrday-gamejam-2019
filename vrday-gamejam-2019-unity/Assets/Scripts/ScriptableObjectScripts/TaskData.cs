using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "n_New_Task_Data", menuName = "BoatLuv/CreateNewTaskData", order = 0)]
public class TaskData : ScriptableObject
{
    public int taskIndex;
    public string taskName;
    public string taskDescription;
    public SuccessCriterion successCriterion;
    public TaskDifficulty taskDifficulty;
    [HideInInspector]
    public int roomIndex;

    //public List<RoomSpecificTaskData> roomSpecificData = new List<RoomSpecificTaskData>();
    [Header("Room Specific Audio Clips")]
    public RoomSpecificAudio barAudio;
    public RoomSpecificAudio poolAudio;
    public RoomSpecificAudio vipAudio;
    public RoomSpecificAudio bedroomAudio;
    public RoomSpecificAudio engineRoomAudio;
    public RoomSpecificAudio casinoAudio;
    public RoomSpecificAudio steeringAudio;
}

public enum TaskDifficulty
{
    Easy,
    Medium,
    Hard,
    Insane
}

public enum SuccessCriterion
{
    Food,
    WaterTemp,
    AirTemp,
    Power,
    WaterLevel,
    Fire,
    SteeringWheel
}
