using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
	public Sprite[] Sprites;
	public Image Image;
	public double Speed;

	void OnEnable()
	{
		StartCoroutine(AnimationRoutine());
	}

	void OnDisable()
	{
		StopAllCoroutines();
	}

	public void PlayOnce(Action done)
	{
		StopAllCoroutines();
		StartCoroutine(AnimationOnceRoutine(done ?? (() => { })));
	}

	IEnumerator AnimationOnceRoutine(Action done)
	{
		yield return null;

		for (int i = 0; i < Sprites.Length; i++)
		{
			Image.sprite = Sprites[i];
			yield return new WaitForSeconds((float)(Mathf.Min(Time.deltaTime, 0.3f) / Speed));
		}

		done();
	}

	IEnumerator AnimationRoutine()
	{
		yield return null;

		var index = 0;
		while (true)
		{
			Image.sprite = Sprites[index++ % Sprites.Length];
			yield return new WaitForSeconds((float)(Mathf.Min(Time.deltaTime, 0.3f) / Speed));
		}
	}
}
