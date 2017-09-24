using System;
using UnityEngine;


public enum Statuses
{
	Default,
	Depressive,
	Anxious,
	Drowsy,
	Alert,
	Paranoid,
	Narcisic
}

public enum Traits
{
	Confidence,
	Happiness,
	Alertness
}

public struct StatusEffect
{
	public Statuses Status;
	public TimeSpan Time;
	public TimeSpan Delay;
	public double Remaining;
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


	public bool IsStatus(Statuses status)
	{
		return true;
	}
	//readonly List<StatusEffect> _effects = new List<StatusEffect>();

	//void Update()
	//{
	//	UpdateEffects();
	//}

	//void UpdateEffects()
	//{
	//	for (int i = 0; i < _effects.Count; i++)
	//	{
	//		var effect = _effects[i];
	//		var deltaTime = TimelineManager.Instance.DeltaTime;
	//		effect.Delay = Utility.Max(effect.Delay - TimelineManager.Instance.DeltaTime, TimeSpan.Zero);
	//		var modifier = effect.Delay <= TimeSpan.Zero ?
	//			Math.Min(TimelineManager.Instance.DeltaTime.TotalSeconds / effect.Time.TotalSeconds, Math.Abs(effect.Remaining)) : 0f;
	//		modifier *= Math.Sign(effect.Remaining);
	//		effect.Remaining -= modifier;

	//		switch (effect.Status)
	//		{
	//			case Status.Confidence:
	//				Confidence += modifier;
	//				break;
	//			case Status.Happiness:
	//				Happiness += modifier;
	//				break;
	//			case Status.Alertness:
	//				Alertness += modifier;
	//				break;
	//		}

	//		if (Math.Abs(effect.Remaining) <= 0.0) _effects.RemoveAt(i--);
	//		else _effects[i] = effect;
	//	}
	//}

	//public void AddEffect(StatusEffect effect) { _effects.Add(effect); }
}