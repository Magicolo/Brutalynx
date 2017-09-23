using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	public event Action OnSpawned = () => { };
	public event Action OnDespawned = () => { };

	public Text Text;
	public float ScaleTime;
	public float TypewriterSpeed;

	public void Display(params string[] lines)
	{
		StartCoroutine(AnimationRoutine(lines));
	}

	IEnumerator AnimationRoutine(string[] lines)
	{
		Text.text = "";

		for (float i = 0; i < ScaleTime; i += Time.deltaTime)
		{
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / ScaleTime);
			yield return null;
		}

		transform.localScale = Vector3.one;
		OnSpawned();

		foreach (var line in lines)
		{
			Text.text = "";

			for (int i = 0; i < line.Length; i++)
			{
				Text.text += line[i];

				for (float delay = 0; delay < 1f / TypewriterSpeed; delay += Time.deltaTime)
					yield return null;
			}

			while (!Input.GetKeyDown(KeyCode.Mouse0)) yield return null;
		}

		yield return new WaitForSeconds(2f);

		for (float i = 0; i < ScaleTime; i += Time.deltaTime)
		{
			transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / ScaleTime);
			yield return null;
		}

		transform.localScale = Vector3.zero;
		OnDespawned();
	}
}

