using UnityEngine;

public class TV : Singleton<TV>
{
	public enum States { On, Off }

	public GameObject On;
	public GameObject Off;
	public States State;

    public AudioSource audioSource;

    void Update()
	{
		On.SetActive(State == States.On);
		Off.SetActive(State == States.Off);
        audioSource.volume = -PlayerManager.Instance.Irritability;
	}

	public void SetState(States state)
	{
		State = state;
        if (State == States.On)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
	}
}
