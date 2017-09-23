using UnityEngine;

public class ExBoss : BossBase
{
	public enum States
	{
		Entering,
		ExDialog1,
		WaitingConsumption1,
		DudeDialog1,
		ExDialog2,
		Done
	}

	public CanvasGroup Group;
	public string[] ExFuriousDialog1;
	public string[] ExDialog1;
	public string[] DudeDialog1;
	public States State;

	public override bool IsDone
	{
		get { return State == States.Done; }
	}

	void OnEnable()
	{
		SetState(States.Entering);
	}

	void SetState(States state)
	{
		switch (state)
		{
			case States.Entering:
				Door.Instance.Enter(Group, () => SetState(States.ExDialog1));
				break;
			case States.ExDialog1:
				if (Status == Statuses.Furious)
					Speak(ExDialog1, () => SetState(States.WaitingConsumption1));
				else
					Speak(ExFuriousDialog1, () => SetState(States.WaitingConsumption1));
				break;
			case States.WaitingConsumption1:
				MushroomManager.Instance.WaitConsumption(m => SetState(States.DudeDialog1));
				break;
			case States.DudeDialog1:
				Dude.Instance.Speak(DudeDialog1, () => SetState(States.ExDialog2));
				break;
			case States.ExDialog2:
				// and so on.
				break;
		}

		State = state;
	}
}
