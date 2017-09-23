public class TelephoneEvent : EventBase
{
	public EventBase Next;

	public override bool IsAvailable(Mushrooms mushroom)
	{
		return true;
	}

	public override EventBase Select(Mushrooms mushroom)
	{
		return Next;
	}
}
