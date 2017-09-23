using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	public event Action OnSpawned = () => { };
	public event Action OnDespawned = () => { };

	public Text Text;
	public double ScaleTime;
	public double TypewriterSpeed;

	public void Display(string text)
	{
		StartCoroutine(AnimationRoutine(text));
	}

	IEnumerator AnimationRoutine(string text)
	{
		Text.text = "";

		for (double i = 0; i < ScaleTime; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (float)(i / ScaleTime));
			yield return null;
		}

		transform.localScale = Vector3.one;
		OnSpawned();

		for (int i = 0; i < text.Length; i++)
		{
			Text.text += text[i];
			yield return new WaitForSeconds((float)(TimelineManager.Instance.DeltaTime.TotalSeconds / TypewriterSpeed));
		}

		Text.text = text;
		yield return new WaitForSeconds(3f);

		for (double i = 0; i < ScaleTime; i += TimelineManager.Instance.DeltaTime.TotalSeconds)
		{
			transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, (float)(i / ScaleTime));
			yield return null;
		}

		transform.localScale = Vector3.zero;
		OnDespawned();
	}
}

