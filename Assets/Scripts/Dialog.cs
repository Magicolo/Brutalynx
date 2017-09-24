using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	public event Action OnSpawned = () => { };
	public event Action OnDespawn = () => { };
	public event Action OnDespawned = () => { };

    public AudioSource AudioSource;
	public Text Text;
	public float ScaleTime;
	public float TypewriterSpeed;

    public Voices voices;
    public List<AudioClip> clips = new List<AudioClip>();

	public void Display(CharacterType type, Boss.Statuses ?status, params string[] lines)
	{
		StartCoroutine(AnimationRoutine(lines));
        clips = voices.GetClip(type, status);
        OnDespawned += StopSound;
	}

    public void PlayNextSound(int caracNumber)
    {
        AudioSource.clip = clips[caracNumber % clips.Count];
        AudioSource.Play();
    }

    public void StopSound()
    {
        AudioSource.Stop();
    }

	IEnumerator AnimationRoutine(string[] lines)
	{
		Text.text = "";

		for (float i = 0; i < ScaleTime; i += Time.deltaTime)
		{
			var ratio = i / ScaleTime;
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sqrt(ratio));
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

                PlayNextSound(i);

				for (float delay = 0; delay < 1f / TypewriterSpeed; delay += Time.deltaTime)
					yield return null;
			}

			while (!Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Space)) yield return null;
		}

		OnDespawn();

		for (float i = 0; i < ScaleTime; i += Time.deltaTime)
		{
			var ratio = i / ScaleTime;
			transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, Mathf.Sqrt(ratio));
			yield return null;
		}

		transform.localScale = Vector3.zero;
		OnDespawned();
	}
}

