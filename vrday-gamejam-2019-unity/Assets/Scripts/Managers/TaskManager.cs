using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public GameObject debugUI;
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

    public void GenerateNewTask(int roomIndex)
    {
        //AddTaskToActive(GetRelevantTask(0), roomIndex);
        int randomIndex = Random.Range(0, availableTasks.Count);
        AddTaskToActive(availableTasks[randomIndex], roomIndex);
    }

    public TaskData GetRelevantTask(int taskWeight)
    {
        TaskData td;
        td = availableTasks[taskWeight];
        return td;
    }

    public void GenerateBarTask(int barIndex)
    {
        AddTaskToActive(availableTasks[0], barIndex);
        debugUI.SetActive(true);

    }

    public void GeneratePoolTask(int poolIndex)
    {
        Debug.Log("GENERATING POOL INDEX");
        AddTaskToActive(availableTasks[0], poolIndex);

    }

    public void CheckForSuccess(SuccessCriterion successAttempt)
    {
        foreach(GameObject go in activeTasks.Values)
        {
            if(successAttempt == go.GetComponent<Task>().thisTaskData.successCriterion)
            {
                DestroyActiveTask(go.GetComponent<Task>().thisTaskData);
                Debug.Log("SUCCESS");
                break;
            }
            
        }
    }

    public void SuccessTestFood()
    {
        Debug.Log("PRESSED FOOD BUTTON");
        CheckForSuccess(SuccessCriterion.Food);
    }

    public void SuccessTestWaterTemp()
    {
        Debug.Log("PRESSED Water BUTTON");
        CheckForSuccess(SuccessCriterion.WaterTemp);
    }

    public void SuccessTestAirTemp()
    {
        Debug.Log("PRESSED Air BUTTON");
        CheckForSuccess(SuccessCriterion.AirTemp);
    }

    public void SuccessTestPower()
    {
        Debug.Log("PRESSED Power BUTTON");
        CheckForSuccess(SuccessCriterion.Power);
    }
}
