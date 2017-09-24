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

    public AudioSource audioSource;
    public AudioClip open;
    public AudioClip close;

    public GameObject Opened;
	public GameObject Closed;
	public float FadeTime = 1f;
	public float Wait = 0.5f;
	public States State;

	public void Open()
	{
		State = States.Opened;
        if (open != null)
        {
            audioSource.clip = open;
            audioSource.Play();
        }
	}

	public void Close()
	{
		State = States.Closed;
        if (close != null)
        {
            audioSource.clip = close;
            audioSource.Play();
        }
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

		yield return new WaitForSeconds(Wait);

		for (float counter = 0; counter < FadeTime; counter += Time.deltaTime)
		{
			group.alpha = counter / FadeTime;
			yield return null;
		}

		group.alpha = 1f;
		yield return new WaitForSeconds(Wait);
		Close();
		yield return null;
		done();
	}

	IEnumerator ExitRoutine(CanvasGroup group, Action done)
	{
		group.alpha = 1f;
		Open();
		yield return new WaitForSeconds(Wait);

		for (float counter = 0; counter < FadeTime; counter += Time.deltaTime)
		{
			group.alpha = 1f - counter / FadeTime;
			yield return null;
		}

		group.alpha = 0f;
		yield return new WaitForSeconds(Wait);
		Close();
		yield return null;
		done();
	}
}
