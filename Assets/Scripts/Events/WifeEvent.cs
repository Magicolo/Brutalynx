using UnityEngine;

public class WifeEvent : EventBase
{
	public enum States
	{
		WifeEntering,
		WifeBubble1,
		WaitingConsumption,
		WifeBubble2,
		WaitingChoice,
		WifeBubble3,
		WifeExiting,
		Done
	}

	public override bool IsDone { get { return State == States.Done; } }

	public States State;
	public GameObject WifePrefab;
	int _count;
	GameObject _wife;

	void OnEnable()
	{
		SetState(States.WifeEntering);
	}

	void OnDisable()
	{
		Destroy(_wife);
	}

	void Update()
	{
		switch (State)
		{
			case States.WaitingConsumption:
				if (MushroomManager.Instance.History.Count > _count)
					SetState(States.WifeBubble2);
				break;
		}
	}

	void SetState(States state)
	{
		switch (state)
		{
			case States.WifeEntering:
				_wife = Instantiate(WifePrefab, UIManager.Instance.Canvas.transform);
				_wife.transform.position = Door.Instance.transform.position;
				Door.Instance.Enter(_wife.GetComponentInChildren<CanvasGroup>(), () => SetState(States.WifeBubble1));
				break;
			//case States.WifeBubble1:
			//	{
			//		var dialog = DialogManager.Instance.Spawn("Hey mouche-taureau!", _wife.transform.position, Characters.NPC);
			//		dialog.OnDespawned += () => SetState(States.WaitingConsumption);
			//		break;
			//	}
			case States.WaitingConsumption:
				_count = MushroomManager.Instance.History.Count;
				break;
			//case States.WifeBubble2:
			//	{
			//		var text = PlayerManager.Instance.IsDepressed ?
			//			"Cabarnoulesque! Ben tousquain le malin?" :
			//			"Honorifique gastongay.";
			//		var dialog = DialogManager.Instance.Spawn(text, _wife.transform.position, Characters.NPC);
			//		dialog.OnDespawned += () => SetState(States.WifeBubble3);
			//		break;
			//	}
			case States.WaitingChoice:
				// Spawn menu.
				break;
			//case States.WifeBubble3:
			//	{
			//		var dialog = DialogManager.Instance.Spawn("Rachidien McSween", _wife.transform.position, Characters.NPC);
			//		dialog.OnDespawned += () => SetState(States.WifeExiting);
			//		break;
			//	}
			case States.WifeExiting:
				Door.Instance.Exit(_wife.GetComponentInChildren<CanvasGroup>(), () => SetState(States.Done));
				break;
		}

		State = state;
	}
}
