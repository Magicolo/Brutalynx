using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
	public static StoryManager Instance { get; private set; }

	public EventBase Current;

	public readonly Stack<Mushrooms> History = new Stack<Mushrooms>();

	void Awake()
	{
		Instance = this;
	}

	public void Select(Mushrooms mushroom)
	{
		History.Push(mushroom);
		Current.gameObject.SetActive(false);
		Current = Current.Select(mushroom);
		Current.gameObject.SetActive(true);
	}
}
