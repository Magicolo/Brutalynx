using UnityEngine;

public class Room : Singleton<Room>
{
	public enum States
	{
		Normal,
		Organic,
		Alien,
		SmokingBoobs,
		Spider,
	}

	public GameObject Normal;
	public GameObject Organic;
	public GameObject Alien;
	public GameObject SmokingBoobs;
	public GameObject Spider;
	public States State;

	void Update()
	{
		Normal.SetActive(State == States.Normal);
		Organic.SetActive(State == States.Organic);
		Alien.SetActive(State == States.Alien);
		SmokingBoobs.SetActive(State == States.SmokingBoobs);
		Spider.SetActive(State == States.Spider);
	}

	public void SetState(States state)
	{
		if (State != state)
			Flash.Instance.FadeOut(0.2f);

		State = state;
	}

	public States FromCharacter(CharacterType character)
	{
		switch (character)
		{
			case CharacterType.Wife: return States.Organic;
			case CharacterType.Kid: return States.Alien;
			case CharacterType.GF: return States.SmokingBoobs;
			case CharacterType.Boss: return States.Spider;
			default: return States.Normal;
		}
	}
}
