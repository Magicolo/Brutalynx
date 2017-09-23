public class TelephoneEvent : EventBase
{
	public enum States
	{
		WaitConsumption,
		WaitChoice,
		TelephoneBubble1,
		Done
	}

	public override bool IsDone { get { return State == States.Done; } }

	public States State;
	int _count;

	void OnEnable()
	{
		SetState(States.WaitConsumption);
	}

	void Update()
	{
		switch (State)
		{
			case States.WaitConsumption:
				if (MushroomManager.Instance.History.Count > _count)
					SetState(States.WaitChoice);
				break;
			case States.WaitChoice:
				// Replace with menu callbacks.
				if (Telephone.Instance.State == Telephone.States.Answered)
					SetState(States.TelephoneBubble1);
				else if (Telephone.Instance.State == Telephone.States.Cancelled)
					SetState(States.Done);
				break;
		}
	}

	void SetState(States state)
	{
		switch (state)
		{
			case States.WaitConsumption:
				Telephone.Instance.Ring(Callers.Mom);
				_count = MushroomManager.Instance.History.Count;
				break;
			case States.WaitChoice:
				// Spawn the menu.
				break;
			case States.TelephoneBubble1:
				var dialog = DialogManager.Instance.Spawn("Simon le cavalier grandissime.", Telephone.Instance.transform.position, Characters.NPC);
				dialog.OnDespawned += () => SetState(States.Done);
				break;
		}

		State = state;
	}
}
