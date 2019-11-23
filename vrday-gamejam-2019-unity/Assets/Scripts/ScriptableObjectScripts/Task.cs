using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Task", menuName = "BoatLuv/CreateNewTask", order = 3)]
public class Task : ScriptableObject
{
    public string taskName;
    public List<Need> needs = new List<Need>();
}
