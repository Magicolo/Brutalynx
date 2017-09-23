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
<<<<<<< b707711ccadad04ff77566c2a2a845155fbe47b5
				{
					BubbleManager.Instance.Spawn(300,200,"Simon le cavalier grandissime.", 0.1f, 5f, Telephone.Instance.gameObject, true);
					State = States.Done;
				}
=======
					SetState(States.TelephoneBubble1);
>>>>>>> 03128ceb75682806e0ff7a0e9a501e0caead39cf
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
				var dialog = DialogManager.Instance.Spawn("Simon le cavalier grandissime.", Telephone.Instance.transform.position);
				dialog.OnDespawned += () => SetState(States.Done);
				break;
		}

		State = state;
	}
}
