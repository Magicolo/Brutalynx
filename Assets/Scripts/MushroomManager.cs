using System;
using System.Collections.Generic;

public class MushroomManager : Singleton<MushroomManager>
{
	readonly Stack<Mushrooms> _history = new Stack<Mushrooms>();

	public void Consume(Mushrooms mushroom)
	{
		switch (mushroom)
		{
			case Mushrooms.Red:
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Happiness,
					Remaining = 0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = -0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = -0.25f,
					Delay = TimeSpan.FromSeconds(120.0)
				});
				break;
			case Mushrooms.Green:
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = 0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = -0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Happiness,
					Remaining = -0.25f,
					Delay = TimeSpan.FromSeconds(120.0)
				});
				break;
			case Mushrooms.Yellow:
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = 0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Happiness,
					Remaining = -0.5f,
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = -0.25f,
					Delay = TimeSpan.FromSeconds(120.0)
				});
				break;
			case Mushrooms.Blue:
				break;
		}

		_history.Push(mushroom);
	}
}

