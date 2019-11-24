using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData thisTaskData;
    public float taskDuration;
    public bool isTaskComplete = false;
    public RoomSpecificAudio thisTaskAudio;
    public Dictionary<TaskEscalation, AudioClip> audioRefs = new Dictionary<TaskEscalation, AudioClip>();

    public delegate void OnTaskStatusChangeDelegate(TaskEscalation newStatus);
    public event OnTaskStatusChangeDelegate OnTaskStatusChange;

    public delegate void OnTaskTimeChangeDelegate(float newVal);
    public event OnTaskTimeChangeDelegate OnTaskTimeChange;

    private void TaskTimeChangeHandler(float newVal)
    {
        int roundedTime = Mathf.RoundToInt(newVal * taskStatusCount) -1;
        if (taskStatus == (TaskEscalation)roundedTime) return;
        TaskStatus = (TaskEscalation)roundedTime;
    }

    private void TaskStatusChangeHandler(TaskEscalation newStatus)
    {
        //Debug.Log(newStatus);
        //AudioManager.Instance.masterAudio.PlayOneShot(thisTaskAudio.annoyedAudio);
    }

    private void OnEnable()
    {
        OnTaskTimeChange += TaskTimeChangeHandler;
        OnTaskStatusChange += TaskStatusChangeHandler;
        taskStatusCount = System.Enum.GetNames(typeof(TaskEscalation)).Length;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        OnTaskTimeChange -= TaskTimeChangeHandler;
        OnTaskStatusChange -= TaskStatusChangeHandler;
    }


    public IEnumerator Counter()
    {
        while(taskTime < 1f)
        {
            TaskTime += Time.deltaTime / taskDuration;
            yield return null;
        }

        yield break;
    }

    public void SetTaskData(TaskData taskData)
    {
        thisTaskData = taskData;
        GetAudio();
        SetDuration(thisTaskData);
        StartCoroutine(Counter());
        //AudioManager.Instance.masterAudio.PlayOneShot(thisTaskAudio.patientAudio);
    }

    private void SetDuration(TaskData taskData)
    {
        switch (taskData.taskDifficulty)
        {
            case TaskDifficulty.Easy:
                taskDuration = 60f;
                break;
            case TaskDifficulty.Medium:
                taskDuration = 45f;
                break;
            case TaskDifficulty.Hard:
                taskDuration = 30f;
                break;
            case TaskDifficulty.Insane:
                taskDuration = 15f;
                break;
        }
    }

    private void GetAudio()
    {
        Debug.Log("CALLING GET AUDIO");
        switch (thisTaskData.roomIndex)
        {
            case 0:
                thisTaskAudio = thisTaskData.barAudio;
                Debug.Log("SETTING TO BAR AUDIO");
                break;
            case 1:
                thisTaskAudio = thisTaskData.poolAudio;
                Debug.Log("SETTING TO POOL AUDIO");
                break;
        }
    }

    private int taskStatusCount;
    private TaskEscalation taskStatus = (TaskEscalation)(-1);
    public TaskEscalation TaskStatus
    {
        get { return taskStatus; }
        set
        {
            if (taskStatus == value) return;
            taskStatus = value;
            OnTaskStatusChange?.Invoke(taskStatus);
        }
    }

    private float taskTime = 0;
    public float TaskTime
    {
        get { return taskTime; }
        set
        {
            if (System.Math.Abs(taskTime - value) <= System.Math.Abs(taskTime * .0001f)) return;
            taskTime = value;
            OnTaskTimeChange?.Invoke(taskTime);
        }
    }
}


