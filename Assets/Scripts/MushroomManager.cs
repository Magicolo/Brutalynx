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
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = -0.5f,
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = -0.25f,
					Speed = 0.5f,
					Delay = 24f
				});
				break;
			case Mushrooms.Green:
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = 0.5f,
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = -0.5f,
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Happiness,
					Remaining = -0.25f,
					Speed = 0.5f,
					Delay = 24f
				});
				break;
			case Mushrooms.Yellow:
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Confidence,
					Remaining = 0.5f,
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Happiness,
					Remaining = -0.5f,
					Speed = 0.5f,
					Delay = 6f
				});
				PlayerManager.Instance.AddEffect(new StatusEffect
				{
					Status = Status.Alertness,
					Remaining = -0.25f,
					Speed = 0.5f,
					Delay = 24f
				});
				break;
			case Mushrooms.Blue:
				break;
		}

		_history.Push(mushroom);
	}
}

