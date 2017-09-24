using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[Serializable]
public class DudeAction
{
	public Statuses Status;
	public string[] Lines;
}

[Serializable]
public class BossAction
{
	public Boss.Statuses Status;
	public string[] Lines;
	public StatusModifier Modifiers;
}

[Serializable]
public class BossCycle
{
	public Mushrooms[] Mushrooms = new Mushrooms[4];
	public BossAction[] Boss;
	public DudeAction[] Dude;
}

public enum CharacterType
{
	Dude,
	Wife,
	Kid,
	GF,
	Boss,
}

[Serializable]
public class StatusModifier
{
	public float Confidence;
	public float Happiness;
	public float Irritability;
}

public class Boss : MonoBehaviour
{
	public enum Statuses
	{
		Default = -1,
		Idle = 0,
		Furious = 1,
		Happy = 2,
		FuckYou = 3,
		Monster = 4,
		Panick = 5,
	}

	public bool IsDone { get; private set; }

	public Statuses Status;
	public CharacterType Type;
	public Animator Animator;
	public CanvasGroup Group;
	public BossCycle[] Cycles;
	public BossAction LastBossAction;
	public DudeAction LastDudeAction;

	protected virtual void OnEnable()
	{
		StartCoroutine(BossRoutine());
	}

	void Update()
	{
		SetStatus(PlayerManager.Instance.ChuTuCrazy() ? Statuses.Furious : Statuses.Idle);
		Room.Instance.SetState(PlayerManager.Instance.ChuTuFuckinBatShitCrazy() ? Room.Instance.FromCharacter(Type) : Room.States.Normal);
	}

	IEnumerator BossRoutine()
	{
		var enterDone = false;
		Door.Instance.Enter(Group, () => enterDone = true);
		while (!enterDone) yield return null;

		foreach (var cycle in Cycles)
		{
			var bossAction =
				cycle.Boss.FirstOrDefault(a => a.Status == Status) ??
				cycle.Boss.FirstOrDefault(a => a.Status == Statuses.Default) ??
				cycle.Boss.FirstOrDefault();

			foreach (var item in PlayBossAction(bossAction)) yield return item;

			MushroomManager.Instance.AvailableMushrooms = cycle.Mushrooms ?? new Mushrooms[0];
			var consumeDone = false;
			MushroomManager.Instance.WaitConsumption(m => consumeDone = true);
			while (!consumeDone) yield return null;

			var dudeAction =
				cycle.Dude.FirstOrDefault(a => PlayerManager.Instance.IsStatus(a.Status)) ??
				cycle.Dude.FirstOrDefault(a => a.Status == global::Statuses.Default) ??
				cycle.Dude.FirstOrDefault();

			foreach (var item in PlayDudeAction(dudeAction)) yield return item;
		}

		foreach (var item in PlayBossAction(LastBossAction)) yield return item;

		var exitDone = false;
		Door.Instance.Exit(Group, () => exitDone = true);
		while (!exitDone) yield return null;

		foreach (var item in PlayDudeAction(LastDudeAction)) yield return item;
		IsDone = true;
	}

	IEnumerable PlayBossAction(BossAction action)
	{
		if (action == null || action.Lines.Length == 0) yield break;

		var done = false;
		Speak(
			action.Lines,
			() =>
			{
				PlayerManager.Instance.Confidence += action.Modifiers.Confidence;
				PlayerManager.Instance.Irritability += action.Modifiers.Irritability;
				PlayerManager.Instance.Happiness += action.Modifiers.Happiness;
				GameManager.Instance.CheckPlayer();
			},
			() => done = true);
		while (!done) yield return null;
		GameManager.Instance.CheckPlayer();
	}

	IEnumerable PlayDudeAction(DudeAction action)
	{
		if (action == null || action.Lines.Length == 0) yield break;

		var done = false;
		Dude.Instance.Speak(action.Lines, () => done = true);
		while (!done) yield return null;
		GameManager.Instance.CheckPlayer();
	}

	protected void Speak(string[] lines, Action preDone = null, Action done = null)
	{
		var dialog = DialogManager.Instance.Spawn(lines, transform.position, Characters.NPC, Type, Status);
		dialog.OnDespawn += preDone;
		dialog.OnDespawned += done;
	}

	protected void SetStatus(Statuses status)
	{
		if (Status != status)
			Flash.Instance.FadeOut(0.2f);

		Animator.SetFloat("Status", (float)status);
		Status = status;
	}
}
