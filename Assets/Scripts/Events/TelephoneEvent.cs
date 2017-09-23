public class TelephoneEvent : EventBase
{
	public override bool IsDone { get { return Telephone.Instance.State == Telephone.States.Idle; } }

	void OnEnable()
	{
		Telephone.Instance.Ring(Callers.Mom);
	}

	void Update()
	{
		if (Telephone.Instance.State == Telephone.States.Answered)
		{
			// Spawn dé bubbles...
		}
		else if (Telephone.Instance.State == Telephone.States.Cancelled)
			Telephone.Instance.Reset();
	}
}
