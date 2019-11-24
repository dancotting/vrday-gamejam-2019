using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [HideInInspector]
    public AudioSource masterAudio;

    public delegate void OnTaskStatusChangeDelegate(TaskEscalation newStatus);
    public event OnTaskStatusChangeDelegate OnTaskStatusChange;

    private void Start()
    {
        masterAudio = GetComponent<AudioSource>();
    }

}
