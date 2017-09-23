using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Door : Singleton<Door>
{
	public enum States
	{
		Opened,
		Closed
	}

	public Image Opened;
	public Image Closed;
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
		if (Input.GetKeyDown(KeyCode.O)) Open();
		if (Input.GetKeyDown(KeyCode.C)) Close();

		Opened.gameObject.SetActive(State == States.Opened);
		Closed.gameObject.SetActive(State == States.Closed);
	}

	IEnumerator EnterRoutine(CanvasGroup group, Action done)
	{
		group.alpha = 0f;

		for (double i = 0; i < 90d; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			group.alpha = (float)(i / 90d);
			yield return null;
		}

		group.alpha = 1f;
		done();
	}

	IEnumerator ExitRoutine(CanvasGroup group, Action done)
	{
		group.alpha = 1f;

		for (double i = 90d; i > 0; i -= TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			group.alpha = (float)(i / 90d);
			yield return null;
		}

		group.alpha = 0f;
		done();
	}
}
