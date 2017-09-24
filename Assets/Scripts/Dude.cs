using System;
using UnityEngine;

public class Dude : Singleton<Dude>
{
	public enum States
	{
		Idle,
		Eating
	}

	public States State;
	public GameObject Idle;
	public ImageAnimation Eating;

	void Update()
	{
		Idle.SetActive(State == States.Idle);
		Eating.gameObject.SetActive(State == States.Eating);
	}

	public void Speak(string[] lines, Action done = null)
	{
		var dialog = DialogManager.Instance.Spawn(lines, transform.position, Characters.Player, CharacterType.Dude);
		dialog.OnDespawned += done;
	}

	public void SetState(States state)
	{
		switch (state)
		{
			case States.Eating:
				Eating.gameObject.SetActive(true);
				Eating.PlayOnce(() => SetState(States.Idle));
				break;
		}

		State = state;
	}
}

