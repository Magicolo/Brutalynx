using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

[Serializable]
public class VoiceData
{
    BossType type;
    List<AudioClip> voiceSounds = new List<AudioClip>();
}