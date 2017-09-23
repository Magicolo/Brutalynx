using System;
using System.Collections.Generic;

[Serializable]
public struct TimelineEvent
{
	public float Time;
	public EventBase Event;
}

public class TimelineManager : Singleton<TimelineManager>
{
	public TimelineEvent[] Events;
	public readonly List<EventBase> ActiveEvents = new List<EventBase>();
	public readonly List<EventBase> PastEvents = new List<EventBase>();

	public float TimeScale { get { return 1f / 60f; } }
	public float Time { get; private set; }
	public float DeltaTime { get { return UnityEngine.Time.deltaTime * TimeScale; } }

	readonly HashSet<int> _events = new HashSet<int>();

	void Update()
	{
		for (int i = 0; i < Events.Length; i++)
		{
			var @event = Events[i];
			if (@event.Time > Time && _events.Add(i))
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
