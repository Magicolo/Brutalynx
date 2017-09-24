using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Flash : Singleton<Flash>
{
	public Image Image;

	protected override void Awake()
	{
		base.Awake();

		FadeOut();
	}

	public void FadeIn(Action done = null)
	{
		StartCoroutine(FadeInRoutine(done ?? (() => { })));
	}

	public void FadeOut(Action done = null)
	{
		StartCoroutine(FadeOutRoutine(done ?? (() => { })));
	}

	IEnumerator FadeInRoutine(Action done)
	{
		var duration = 4f;
		var color = Image.color;
		var position = UIManager.Instance.Root.position;
		color.a = 0f;
		Image.color = color;
		Image.enabled = true;

		for (float i = 0; i < duration; i += Time.deltaTime)
		{
			color.a = i / duration;
			Image.color = color;
			UIManager.Instance.Root.position = position + (Vector3)UnityEngine.Random.insideUnitCircle * 3f;
			yield return null;
		}

		color.a = 1f;
		Image.color = color;
		yield return new WaitForSeconds(2f);
		done();
	}

	IEnumerator FadeOutRoutine(Action done)
	{
		var duration = 2f;
		var color = Image.color;
		color.a = 1f;
		Image.color = color;
		Image.enabled = true;

		for (float i = 0; i < duration; i += Time.deltaTime)
		{
			color.a = 1f - (i / duration);
			Image.color = color;
			yield return null;
		}

		color.a = 0f;
		Image.color = color;
		Image.enabled = false;
		done();
	}
}
