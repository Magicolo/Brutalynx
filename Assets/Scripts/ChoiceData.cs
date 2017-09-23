using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

[Serializable]
public class ChoiceData
{
    public string text;
    public List<UnityEvent> onClick = new List<UnityEvent>();
}