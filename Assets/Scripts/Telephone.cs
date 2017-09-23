using System.Collections;
using UnityEngine;

public enum Callers
{
	Mom,
	ManInGrey
}

public class Telephone : Singleton<Telephone>
{
	public enum States
	{
		Idle,
		Ringing,
		Answered,
		Cancelled,
	}

	public float ShakeAmplitude = 1f;

	public States State { get; private set; }
	public Callers Caller { get; private set; }

	public void Ring(Callers caller)
	{
		Caller = caller;
		State = States.Ringing;
		StartCoroutine(RingRoutine());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
			Answer();
	}

	public void Answer()
	{
		State = States.Answered;

		// Do something.
	}

	public void Cancel()
	{
		State = States.Cancelled;
	}

	IEnumerator RingRoutine()
	{
		var position = transform.position;

		while (State == States.Ringing)
		{
			// Delay of 30 seconds.
			for (double i = 0f; i < 90f; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
				yield return null;

			// Shake for 30 seconds.
			for (double i = 0f; i < 30f; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
			{
				transform.position = position + (Vector3)Random.insideUnitCircle * ShakeAmplitude;
				yield return null;
			}

			transform.position = position;
		}
	}
}
