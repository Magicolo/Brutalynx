using System;
using System.Collections.Generic;

[Serializable]
public struct TimelineEvent
{
	public float Hour;
	public EventBase Event;
}

public class TimelineManager : Singleton<TimelineManager>
{
	public TimelineEvent[] Events;
	public readonly List<EventBase> ActiveEvents = new List<EventBase>();
	public readonly List<EventBase> PastEvents = new List<EventBase>();

	public float TimeScale { get { return 300f; } }
	public TimeSpan Time { get; private set; }
	public TimeSpan DeltaTime { get { return TimeSpan.FromSeconds(UnityEngine.Time.deltaTime * TimeScale); } }

	readonly HashSet<int> _events = new HashSet<int>();

	void Update()
	{
		if (ActiveEvents.Count <= 0) Time += DeltaTime;

		for (int i = 0; i < Events.Length; i++)
		{
			var @event = Events[i];
			if (Time.TotalHours > @event.Hour && _events.Add(i))
			{
				@event.Event.gameObject.SetActive(true);
				ActiveEvents.Add(@event.Event);
			}
		}

		for (int i = 0; i < ActiveEvents.Count; i++)
		{
			var @event = ActiveEvents[i];
			if (@event.IsDone)
			{
				@event.gameObject.SetActive(false);
				PastEvents.Add(@event);
				ActiveEvents.RemoveAt(i--);
			}
		}
	}
}
