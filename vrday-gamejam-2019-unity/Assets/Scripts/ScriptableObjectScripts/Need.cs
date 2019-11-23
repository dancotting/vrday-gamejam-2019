using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Need", menuName = "BoatLuv/CreateNewNeed", order = 2)]
public class Need : ScriptableObject
{
    public string needName;
    public List<AudioClip> audioClips = new List<AudioClip>();

}
