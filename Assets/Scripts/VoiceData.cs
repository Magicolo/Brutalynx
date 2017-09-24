using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

[Serializable]
public class VoiceData
{
    public CharacterType type;
    public Boss.Statuses status;
    public List<AudioClip> voiceSounds = new List<AudioClip>();
}