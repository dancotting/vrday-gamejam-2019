using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Task_Event", menuName = "BoatLuv/CreateNewTaskEvent", order = 3)]
public class TaskEvent : ScriptableObject
{
    public Task task;
    public Room room;
}
