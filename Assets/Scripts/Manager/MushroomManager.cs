using System;
using System.Collections.Generic;

public class MushroomManager : Singleton<MushroomManager>
{
	public bool IsWaiting;
	public readonly Stack<Mushrooms> History = new Stack<Mushrooms>();

	Action<Mushrooms> listener = m => { };

	public void Consume(Mushrooms mushroom)
	{
		// Add constant shroom effects.

		//switch (mushroom)
		//{
		//	case Mushrooms.Red:
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Happiness,
		//			Remaining = 0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Alertness,
		//			Remaining = -0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Confidence,
		//			Remaining = -0.25f,
		//			Delay = TimeSpan.FromSeconds(120.0)
		//		});
		//		break;
		//	case Mushrooms.Green:
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Alertness,
		//			Remaining = 0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Confidence,
		//			Remaining = -0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Happiness,
		//			Remaining = -0.25f,
		//			Delay = TimeSpan.FromSeconds(120.0)
		//		});
		//		break;
		//	case Mushrooms.Yellow:
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Confidence,
		//			Remaining = 0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Happiness,
		//			Remaining = -0.5f,
		//		});
		//		PlayerManager.Instance.AddEffect(new StatusEffect
		//		{
		//			Status = Status.Alertness,
		//			Remaining = -0.25f,
		//			Delay = TimeSpan.FromSeconds(120.0)
		//		});
		//		break;
		//	case Mushrooms.Blue:
		//		break;
		//}

		History.Push(mushroom);
		IsWaiting = false;
		listener(mushroom);
		listener = m => { };
	}

	public void WaitConsumption(Action<Mushrooms> consumed)
	{
		listener += consumed;
		IsWaiting = true;
	}
}

