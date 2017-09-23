public class TelephoneEvent : EventBase
{
	public enum States
	{
		WaitConsumption,
		WaitTelephone,
		Done
	}

	public override bool IsDone { get { return State == States.Done; } }

	public States State;
	int _count;

	void OnEnable()
	{
		Telephone.Instance.Ring(Callers.Mom);
		State = States.WaitConsumption;
		_count = MushroomManager.Instance.History.Count;
	}

	void Update()
	{
		switch (State)
		{
			case States.WaitConsumption:
				if (MushroomManager.Instance.History.Count > _count)
				{
					State = States.WaitTelephone;
					// Spawn the menu.
				}
				break;
			case States.WaitTelephone:
				if (Telephone.Instance.State == Telephone.States.Answered)
				{
					BubbleManager.Instance.Spawn("Simon le cavalier grandissime.", 0.1f, 5f, Telephone.Instance.gameObject, 50f, 20f, true);
					State = States.Done;
				}
				else if (Telephone.Instance.State == Telephone.States.Cancelled)
					State = States.Done;
				break;
		}
	}
}
