using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public GameObject taskPrefab;
    public List<TaskData> availableTasks = new List<TaskData>();
    public Dictionary<int, GameObject> activeTasks = new Dictionary<int, GameObject>();

    // Manage References to the active tasks in the scene
    // Tasks are components on Active Gameobjects

    public void AddTaskToActive(TaskData taskData, int roomIndex)
    {
        taskData.roomIndex = roomIndex;
        if (!activeTasks.ContainsKey(taskData.taskIndex))
        {
            activeTasks.Add(taskData.taskIndex, CreateNewTask(taskData));
        }
    }

    public void RemoveTaskFromActive(TaskData taskData)
    {
        activeTasks.Remove(taskData.taskIndex);
    }
    // Create and destroy the actual task gameobjects

    public GameObject CreateNewTask(TaskData taskData)
    {
        GameObject newTask = Instantiate(taskPrefab, gameObject.transform);
        newTask.GetComponent<Task>().SetTaskData(taskData);
        newTask.name = (taskData.taskName + " " + taskData.taskIndex);
        return newTask;
    }

    public void DestroyActiveTask(TaskData taskData)
    {
        GameObject go;
        if (activeTasks.TryGetValue(taskData.taskIndex, out go))
        {
            Destroy(go);
            RemoveTaskFromActive(taskData);
        }
    }

    public void GenerateBarTask(int barIndex)
    {
        AddTaskToActive(availableTasks[0], barIndex);

    }

    public void GeneratePoolTask(int poolIndex)
    {
        Debug.Log("GENERATING POOL INDEX");
        AddTaskToActive(availableTasks[0], poolIndex);

    }
}
