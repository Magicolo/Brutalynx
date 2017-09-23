public class TelephoneEvent : EventBase
{
	public enum States
	{
		WaitConsumption,
		WaitTelephone,
		Done
	}

	public override bool IsDone { get { return _state == States.Done; } }

	States _state;
	int _count;

	void OnEnable()
	{
		Telephone.Instance.Ring(Callers.Mom);
		_state = States.WaitConsumption;
		_count = MushroomManager.Instance.History.Count;
	}

	void Update()
	{
		switch (_state)
		{
			case States.WaitConsumption:
				if (MushroomManager.Instance.History.Count > _count)
				{
					_state = States.WaitTelephone;
					// Spawn the menu.
				}
				break;
			case States.WaitTelephone:
				if (Telephone.Instance.State == Telephone.States.Answered)
				{
					BubbleManager.Instance.Spawn("Simon le cavalier grandissime.", 0.1f, 5f, Telephone.Instance.gameObject, 50f, 20f, true);
					_state = States.Done;
				}
				else if (Telephone.Instance.State == Telephone.States.Cancelled)
					_state = States.Done;
				break;
		}
	}
}
