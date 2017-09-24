using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[AddComponentMenu("Voices", 1)]
public class Voices : ScriptableObject
{
    List<VoiceData> voices = new List<VoiceData>();
}