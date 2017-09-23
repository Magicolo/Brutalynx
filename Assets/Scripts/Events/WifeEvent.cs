using UnityEngine;

public class WifeEvent : EventBase
{
	public enum States
	{
		WifeEntering,
		WaitingConsumption,
		Done
	}

	public override bool IsDone { get { return State == States.Done; } }

	public States State;
	public GameObject WifePrefab;
	int _count;
	GameObject _wife;

	void OnEnable()
	{
		State = States.WifeEntering;
		_count = MushroomManager.Instance.History.Count;
		_wife = Instantiate(WifePrefab, UIManager.Instance.Canvas.transform);
		_wife.transform.position = Door.Instance.transform.position;
		Door.Instance.Enter(_wife.GetComponentInChildren<CanvasGroup>(), () => State = States.WaitingConsumption);
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
				{
					Destroy(_wife);
					State = States.Done;
				}
				break;
		}
	}
}
