using UnityEngine;

public class Room : Singleton<Room>
{
	public enum States
	{
		Normal,
		Organic,
		Alien,
		SmokingBoobs,
	}

	public GameObject Normal;
	public GameObject Organic;
	public GameObject Alien;
	public GameObject SmokingBoobs;
	public States State;

	void Update()
	{
		Normal.SetActive(State == States.Normal);
		Organic.SetActive(State == States.Organic);
		Alien.SetActive(State == States.Alien);
		SmokingBoobs.SetActive(State == States.SmokingBoobs);
	}

	public void SetState(States state)
	{
		State = state;
	}
}
