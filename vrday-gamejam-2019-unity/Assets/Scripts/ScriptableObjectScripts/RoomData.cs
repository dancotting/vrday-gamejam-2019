using UnityEngine;

[CreateAssetMenu(fileName = "New_Room_Data", menuName = "BoatLuv/CreateNewRoomData", order = 2)]
public class RoomData : ScriptableObject
{
    public string roomName;
    public AudioClip thisRoomClip;
}
