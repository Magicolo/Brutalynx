using UnityEngine;

public class TV : Singleton<TV>
{
	public enum States { On, Off }

	public GameObject On;
	public GameObject Off;
	public States State;

	void Update()
	{
		On.SetActive(State == States.On);
		Off.SetActive(State == States.Off);
	}

	public void SetState(States state)
	{
		State = state;
	}
}
