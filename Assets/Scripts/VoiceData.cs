using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VoiceData
{
	public CharacterType type;
	public Boss.Statuses status;
	public List<AudioClip> voiceSounds = new List<AudioClip>();
}