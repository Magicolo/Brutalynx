using System;
using UnityEngine;


public enum Statuses
{
	Default,
	Tristesse,
	Extase,
	Terreur,
	Narcicique,
	Rage,
	Fanatisme,
}

public enum Traits
{
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

	public bool IsParanoiac { get { return Confidence <= -1f; } }
	public bool IsDepressed { get { return Happiness <= -1f; } }
	public bool IsDrowsy { get { return Confidence <= -1f; } }
	public bool IsNarcisic { get { return Confidence >= 1f; } }
	public bool IsEuphoric { get { return Happiness >= 1f; } }
	public bool IsOversensitive { get { return Confidence >= 1f; } }

	public bool IsStatus(Statuses status)
	{
		switch (status)
		{
			case Statuses.Terreur: return Confidence <= -0.5f;
			case Statuses.Rage: return Irritability <= -0.5f;
			case Statuses.Tristesse: return Happiness <= -0.5f;
			case Statuses.Extase: return Happiness >= 0.5f;
			case Statuses.Narcicique: return Confidence <= 0.5f;
			case Statuses.Fanatisme: return Irritability >= 0.5f;
			case Statuses.Default: return true;
		}

		return false;
	}
}