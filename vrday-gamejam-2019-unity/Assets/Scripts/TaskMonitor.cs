using UnityEngine;
using UnityEngine.UI;

public class TaskMonitor : MonoBehaviour
{
    public RectTransform masterContainer;
    public float maxWidth;
    public float maxHeight;
    public RectTransform progressContainer;
    public Task taskToMonitor;

    private void Start()
    {
        maxWidth = masterContainer.rect.width;
        maxHeight = masterContainer.rect.height;
        GameObject go;
        if(TaskManager.Instance.activeTasks.TryGetValue(0, out go))
        {
            taskToMonitor = go.GetComponent<Task>();
        }

    }

    private void Update()
    {
        if (taskToMonitor)
        {
            progressContainer.sizeDelta = new Vector2(taskToMonitor.TaskTime * maxWidth, 0);
        }
        
    }
}

public enum TaskEscalation
{
    LevelOne,
    LevelTwo,
    LevelThree,
    LevelFour,
    LevelFive,
    LevelSix,
    TaskFailure
}