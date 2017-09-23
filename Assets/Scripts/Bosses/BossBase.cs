using System;
using UnityEngine;

public class BossBase : MonoBehaviour
{
	public enum Statuses
	{
		Idle = 0,
		Furious = 1,
		Happy = 2,
	}

	public Statuses Status;
	public Animator Animator;

	protected void Speak(string[] lines, Action done)
	{
		var dialog = DialogManager.Instance.Spawn(lines, transform.position, Characters.NPC);
		dialog.OnDespawned += done;
	}

	protected void SetStatus(Statuses status)
	{
		Animator.SetFloat("Status", (float)status);
		Status = status;
	}
}
