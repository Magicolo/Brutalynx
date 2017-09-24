using System.Collections;
using UnityEngine;

public class MusicManager : Singleton<MushroomManager>
{
	public enum States
	{
		Normal,
		Dying
	}

	public AudioSource[] Songs;
	public AudioSource DeathSong;
	public States State;

	float _duck = 1f;

	protected override void Start()
	{
		base.Start();

		StartCoroutine(MusicRoutine());
	}

	void Update()
	{
		SetState(PlayerManager.Instance.ChuTuFuckinBatShitCrazy() ? States.Dying : States.Normal);
	}

	IEnumerator MusicRoutine()
	{
		if (Songs.Length < 2) yield break;

		var fade = 10f;
		int index = 0;
		while (true)
		{
			var current = Songs[index++ % Songs.Length];
			if (!current.isPlaying) current.Play();

			while (current.time < current.clip.length - fade)
			{
				current.volume = _duck;
				yield return null;
			}

			var next = Songs[(index) % Songs.Length];
			next.volume = 0f;
			next.Play();

			for (float counter = 0; counter < fade; counter += Time.deltaTime)
			{
				var ratio = Mathf.Sqrt(counter / fade);
				current.volume = (1f - ratio) * _duck;
				next.volume = ratio * _duck;
				yield return null;
			}

			current.Stop();
			next.volume = 1f;

			yield return null;
		}
	}

	IEnumerator DeathRoutine()
	{
		var fade = 5f;

		while (State == States.Dying)
			yield return null;

		for (float counter = 0; counter < fade; counter += Time.deltaTime)
		{
			var ratio = Mathf.Sqrt(counter / fade);
			_duck = ratio;
			DeathSong.volume = 1f - ratio;
			yield return null;
		}

		DeathSong.Stop();
	}

	void SetState(States state)
	{
		if (State == state) return;
		State = state;

		switch (state)
		{
			case States.Dying:
				_duck = 0f;
				DeathSong.volume = 1f;
				DeathSong.Play();
				StartCoroutine(DeathRoutine());
				break;
		}
	}
}
