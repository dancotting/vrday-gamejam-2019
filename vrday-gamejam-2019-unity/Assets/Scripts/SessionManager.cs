using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    public int currentActiveTasks;
    public int completedTasks;
    public int failedTasks;
    public float percentRemainingAtCompletion;
    public float sessionTime;
    public float sessionDuration = 150f;
    public float spawnRate;

    private void Start()
    {
        StartCoroutine(sessionCounter());
    }

    public IEnumerator sessionCounter()
    {
        while(sessionTime < 1)
        {
            sessionTime += Time.deltaTime / sessionDuration;
            yield return null;
        }

        Debug.LogWarning("SESSION OVER");
        yield break;
    }

    //public void SpawnTask()
    //{
    //    if(currentActiveTasks == 0)
    //    {
    //        TaskManager.Instance.
    //    }
    //}
}
