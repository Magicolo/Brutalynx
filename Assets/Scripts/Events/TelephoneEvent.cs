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
			BubbleManager.Instance.Spawn("Simon le cavalier grandissime.", 0.1f, 5f, Telephone.Instance.gameObject, 100f, 100f, true);
		else if (Telephone.Instance.State == Telephone.States.Cancelled)
			Telephone.Instance.Reset();
	}
}
