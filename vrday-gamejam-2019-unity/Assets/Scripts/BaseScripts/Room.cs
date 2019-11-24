using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Room : MonoBehaviour
{
    public Image roomStatusIndicator;
    public Button roomAckButton;
    public GameObject taskMonitorPrefab;
    public Transform taskMonitorParent;
    public List<GameObject> taskStatusMonitors = new List<GameObject>();

    public void AddTaskMonitor()
    {
        GameObject taskMonitor = Instantiate(taskMonitorPrefab, taskMonitorParent);
        taskStatusMonitors.Add(taskMonitor);

    }

    public enum RoomMood
    {
        patient,
        annoyed,
        irate
    }
}
