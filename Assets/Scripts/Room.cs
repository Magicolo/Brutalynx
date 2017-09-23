using UnityEngine;

public class Room : Singleton<Room>
{
	public enum States { Normal, Organic }

	public GameObject Normal;
	public GameObject Organic;
	public States State;

	void Update()
	{
		Normal.SetActive(State == States.Normal);
		Organic.SetActive(State == States.Organic);
	}

	public void SetState(States state)
	{
		State = state;
	}
}
