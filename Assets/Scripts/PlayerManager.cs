using System.Collections.Generic;
using UnityEngine;


public enum Status
{
	Confidence,
	Happiness,
	Alertness
}

public struct StatusEffect
{
	public Status Status;
	public float Speed;
	public float Remaining;
	public float Delay;
}

public class PlayerManager : Singleton<PlayerManager>
{
	[Range(-1f, 1f)]
	public float Confidence;
	[Range(-1f, 1f)]
	public float Happiness;
	[Range(-1f, 1f)]
	public float Alertness;

	public bool IsParanoiac { get { return Confidence <= -1f; } }
	public bool IsDepressed { get { return Happiness <= -1f; } }
	public bool IsDrowsy { get { return Alertness <= -1f; } }
	public bool IsNarcisic { get { return Confidence >= 1f; } }
	public bool IsEuphoric { get { return Happiness >= 1f; } }
	public bool IsOversensitive { get { return Alertness >= 1f; } }

	readonly List<StatusEffect> _effects = new List<StatusEffect>();

	void Update()
	{
		UpdateEffects();
	}

	void UpdateEffects()
	{
		for (int i = 0; i < _effects.Count; i++)
		{
			var effect = _effects[i];
			var deltaTime = TimelineManager.Instance.DeltaTime;
			effect.Delay = Mathf.Max(effect.Delay - TimelineManager.Instance.DeltaTime, 0f);
			var modifier = effect.Delay <= 0f ?
				Mathf.Min(TimelineManager.Instance.DeltaTime * effect.Speed, effect.Remaining) : 0f;
			effect.Remaining -= modifier;

			switch (effect.Status)
			{
				case Status.Confidence:
					Confidence -= modifier;
					break;
				case Status.Happiness:
					Happiness -= modifier;
					break;
				case Status.Alertness:
					Alertness -= modifier;
					break;
			}

			if (effect.Remaining <= 0f) _effects.RemoveAt(i--);
			else _effects[i] = effect;
		}
	}

	public void AddEffect(StatusEffect effect) { _effects.Add(effect); }
}