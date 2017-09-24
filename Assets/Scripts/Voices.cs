using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Voice", menuName = "Voice", order = 101)]
public class Voices : ScriptableObject
{
	public List<VoiceData> voices = new List<VoiceData>();

	public List<AudioClip> GetClip(CharacterType type, Boss.Statuses? status = null)
	{
		List<AudioClip> clips = new List<AudioClip>();

		if (status != null)
			foreach (VoiceData v in voices)
			{
				if (v.status == status && v.type == type)
				{
					clips = v.voiceSounds;
					break;
				}
			}

		if (clips.Count == 0)
			clips = GetDefaultClip(type);


		return clips;
	}

	public List<AudioClip> GetDefaultClip(CharacterType type)
	{
		List<AudioClip> clips = new List<AudioClip>();

		foreach (VoiceData v in voices)
		{
			if (v.status == Boss.Statuses.Default && v.type == type)
			{
				clips = v.voiceSounds;
				break;
			}
		}

		return clips;
	}

}