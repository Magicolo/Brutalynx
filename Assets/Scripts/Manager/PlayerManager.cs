using System;
using UnityEngine;


public enum Statuses
{
	Default,
	Depression,
	Anxiety,
	Terror,
	Recklessness,
	Rage,
	Numbess,
}

public enum Traits
{
	None,
	Happiness,
	Confidence,
	Irritability
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
	public float Happiness;
	[Range(-1f, 1f)]
	public float Confidence;
	[Range(-1f, 1f)]
	public float Irritability;

	public void ResetTraits()
	{
		Happiness = 0f;
		Confidence = 0f;
		Irritability = 0f;
	}

	public bool ChuTuCrazy(/*float threshold = 0.6f*/)
	{
		return Mathf.Abs(Happiness) + Mathf.Abs(Confidence) + Mathf.Abs(Irritability) > 1f;

		//var count =
		//	(Mathf.Abs(Happiness) >= threshold ? 1 : 0) +
		//	(Mathf.Abs(Confidence) >= threshold ? 1 : 0) +
		//	(Mathf.Abs(Irritability) >= threshold ? 1 : 0);
		//return count >= 2;
	}

	public bool ChuTuFuckinBatShitCrazy(/*float threshold = 0.8f*/)
	{
		return Mathf.Abs(Happiness) + Mathf.Abs(Confidence) + Mathf.Abs(Irritability) >= 1.5f;

		//var count =
		//	(Mathf.Abs(Happiness) >= threshold ? 1 : 0) +
		//	(Mathf.Abs(Confidence) >= threshold ? 1 : 0) +
		//	(Mathf.Abs(Irritability) >= threshold ? 1 : 0);
		//return count >= 2;
	}

	public bool IsStatus(Statuses status)
	{
		switch (status)
		{
			case Statuses.Terror: return Confidence <= -0.5f;
			case Statuses.Rage: return Irritability <= -0.5f;
			case Statuses.Depression: return Happiness <= -0.5f;
			case Statuses.Anxiety: return Happiness >= 0.5f;
			case Statuses.Recklessness: return Confidence >= 0.5f;
			case Statuses.Numbess: return Irritability >= 0.5f;
			case Statuses.Default: return true;
		}

		return false;
	}

	public Traits GetTrait(Statuses status)
	{
		switch (status)
		{
			case Statuses.Depression:
			case Statuses.Anxiety: return Traits.Happiness;
			case Statuses.Terror:
			case Statuses.Recklessness: return Traits.Confidence;
			case Statuses.Rage:
			case Statuses.Numbess: return Traits.Irritability;
			default:
			case Statuses.Default: return Traits.None;
		}
	}

	public float GetTraitValue(Traits trait)
	{
		switch (trait)
		{
			case Traits.Happiness: return Happiness;
			case Traits.Confidence: return Confidence;
			case Traits.Irritability: return Irritability;
			default:
			case Traits.None: return 0f;
		}
	}

	public float GetTraitValue(Statuses status) { return GetTraitValue(GetTrait(status)); }
}