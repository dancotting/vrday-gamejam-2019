using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{

    public void PlayAudio(RoomData roomData)
    {
        AudioManager.Instance.masterAudio.PlayOneShot(roomData.thisRoomClip);
    }

    public void AddTaskToRoom(Task newTask)
    {
        //thisRoom.activeTasks.Add(newTask);
        Debug.Log(newTask.name);
    }
}
