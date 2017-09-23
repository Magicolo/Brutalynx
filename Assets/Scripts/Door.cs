using System;
using System.Collections;
using UnityEngine;

public class Door : Singleton<Door>
{
	public enum States
	{
		Opened,
		Closed
	}

	public GameObject Opened;
	public GameObject Closed;
	public States State;

	public void Open()
	{
		State = States.Opened;
	}

	public void Close()
	{
		State = States.Closed;
	}

	public void Enter(CanvasGroup group, Action done)
	{
		StartCoroutine(EnterRoutine(group, done));
	}

	public void Exit(CanvasGroup group, Action done)
	{
		StartCoroutine(ExitRoutine(group, done));
	}

	void Update()
	{
		Opened.SetActive(State == States.Opened);
		Closed.SetActive(State == States.Closed);
	}

	IEnumerator EnterRoutine(CanvasGroup group, Action done)
	{
		group.alpha = 0f;
		Open();
		yield return null;

		for (double i = 0; i < 90d; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			group.alpha = (float)(i / 90d);
			yield return null;
		}

		group.alpha = 1f;
		Close();
		yield return null;
		done();
	}

	IEnumerator ExitRoutine(CanvasGroup group, Action done)
	{
		group.alpha = 1f;
		Open();
		yield return null;

		for (double i = 90d; i > 0; i -= TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			group.alpha = (float)(i / 90d);
			yield return null;
		}

		group.alpha = 0f;
		Close();
		yield return null;
		done();
	}
}
