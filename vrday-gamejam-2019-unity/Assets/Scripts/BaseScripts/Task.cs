using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData thisTaskData;
    public float taskDuration;
    public bool isTaskComplete = false;
    public Dictionary<TaskEscalation, AudioClip> audioRefs = new Dictionary<TaskEscalation, AudioClip>();

    public delegate void OnTaskStatusChangeDelegate(TaskEscalation newStatus);
    public event OnTaskStatusChangeDelegate OnTaskStatusChange;

    public delegate void OnTaskTimeChangeDelegate(float newVal);
    public event OnTaskTimeChangeDelegate OnTaskTimeChange;

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
        while (taskTime < 1f)
        {
            TaskTime += Time.deltaTime / taskDuration;
            yield return null;
        }
        FailState();
        yield break;
    }

    private void TaskTimeChangeHandler(float newVal)
    {
        int roundedTime = Mathf.RoundToInt(newVal * taskStatusCount) - 1;
        if (taskStatus == (TaskEscalation)roundedTime) return;
        TaskStatus = (TaskEscalation)roundedTime;
    }

    private void TaskStatusChangeHandler(TaskEscalation newStatus)
    {
        PlayTaskAudio();
    }

    private void FailState()
    {
        SessionManager.Instance.failedTasks++;
        TaskManager.Instance.DestroyActiveTask(thisTaskData);
    }

    public void SetTaskData(TaskData taskData)
    {
        thisTaskData = taskData;
        taskDuration = (float)thisTaskData.taskDifficulty;
        GetAudio();
        StartCoroutine(Counter());
        PlayTaskAudio();
    }

    private void GetAudio()
    {
        List<AudioClip> thisTaskAudio = new List<AudioClip>();
        switch (thisTaskData.roomIndex)
        {
            case 0:
                thisTaskAudio = thisTaskData.barAudio.roomAudioClips;
                Debug.Log("SETTING TO BAR AUDIO");
                break;
            case 1:
                thisTaskAudio = thisTaskData.poolAudio.roomAudioClips;
                Debug.Log("SETTING TO POOL AUDIO");
                break;
        }

        SetAudioRefs(thisTaskAudio);
    }

    private void SetAudioRefs(List<AudioClip> clips)
    {
        for (int i = 0; i < clips.Count; i++)
        {
            audioRefs.Add((TaskEscalation)i, clips[i]);
        }
    }

    private void PlayTaskAudio()
    {
        if (audioRefs.TryGetValue(taskStatus, out AudioClip clip))
        {
            AudioManager.Instance.masterAudio.PlayOneShot(clip);
        }
    }

    private int taskStatusCount;
    private TaskEscalation taskStatus = TaskEscalation.LevelOne;
    public TaskEscalation TaskStatus
    {
        get { return taskStatus; }
        set
        {
            if (taskStatus == value || value < 0) return;
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


