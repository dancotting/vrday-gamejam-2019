using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [HideInInspector]
    public AudioSource masterAudio;

    private void Start()
    {
        masterAudio = GetComponent<AudioSource>();
    }

}
