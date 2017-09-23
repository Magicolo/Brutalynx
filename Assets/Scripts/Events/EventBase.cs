using UnityEngine;

public abstract class EventBase : MonoBehaviour
{
	public abstract bool IsAvailable(Mushrooms mushroom);
	public abstract EventBase Select(Mushrooms mushroom);
}

