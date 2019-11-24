﻿using System.Collections;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData thisTaskData;
    public Room roomAssignment;
    public float taskDuration;
    public float taskTime = 0f;
    public RoomSpecificAudio thisTaskAudio;

    public IEnumerator Counter()
    {
        while(taskTime < .33f)
        {
            taskTime += Time.deltaTime / taskDuration;
            yield return null;
        }

        PlayAudio(thisTaskAudio.annoyedAudio);

        while (taskTime > .33f && taskTime < .66f)
        {
            taskTime += Time.deltaTime / taskDuration;
            yield return null;
        }

        PlayAudio(thisTaskAudio.irateAudio);

        while (taskTime > .66f && taskTime < 1f)
        {
            taskTime += Time.deltaTime / taskDuration;
            yield return null;
        }
        TaskManager.Instance.DestroyActiveTask(thisTaskData);
        yield break;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetTaskData(TaskData taskData)
    {
        thisTaskData = taskData;
        GetAudio();
        SetDuration(thisTaskData);
        StartCoroutine(Counter());
        PlayAudio(thisTaskAudio.patientAudio);
    }

    private void PlayAudio(AudioClip clip)
    {
        AudioManager.Instance.masterAudio.PlayOneShot(clip);
        Debug.Log(clip.name);
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
}