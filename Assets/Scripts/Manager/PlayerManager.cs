using System;
using UnityEngine;


public enum Statuses
{
	Default,
	Tristesse,
	Extase,
	Terreur,
	Narcissique,
	Rage,
	Fanatisme,
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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Happiness += 1983759;
			GameManager.Instance.CheckPlayer();
		}
	}

	public bool IsStatus(Statuses status)
	{
		switch (status)
		{
			case Statuses.Terreur: return Confidence <= -0.5f;
			case Statuses.Rage: return Irritability <= -0.5f;
			case Statuses.Tristesse: return Happiness <= -0.5f;
			case Statuses.Extase: return Happiness >= 0.5f;
			case Statuses.Narcissique: return Confidence <= 0.5f;
			case Statuses.Fanatisme: return Irritability >= 0.5f;
			case Statuses.Default: return true;
		}

		return false;
	}

	public Traits GetTrait(Statuses status)
	{
		switch (status)
		{
			case Statuses.Tristesse:
			case Statuses.Extase: return Traits.Happiness;
			case Statuses.Terreur:
			case Statuses.Narcissique: return Traits.Confidence;
			case Statuses.Rage:
			case Statuses.Fanatisme: return Traits.Irritability;
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