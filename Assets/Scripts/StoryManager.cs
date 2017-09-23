using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
	public static StoryManager Instance { get; private set; }

	public float Time { get; private set; }
	public EventBase Current;

	public readonly Stack<Mushrooms> History = new Stack<Mushrooms>();

	void Awake()
	{
		Instance = this;
	}

	void Update()
	{
		Time += UnityEngine.Time.deltaTime;
	}

	public void Select(Mushrooms mushroom)
	{
		// Add the logic for the effects of mushrooms.
		// Must be here because it might depend on past consumption.
		//switch (mushroom)
		//{
		//	case Mushrooms.Red:
		//		if (History.Peek() == Mushrooms.Green)
		//			PlayerManager.Instance.Boredom += 10259847;
		//		break;
		//	case Mushrooms.Green:
		//		break;
		//	case Mushrooms.Yellow:
		//		break;
		//	case Mushrooms.Blue:
		//		break;
		//}

		History.Push(mushroom);
		Current.gameObject.SetActive(false);
		Current = Current.Select(mushroom);
		Current.gameObject.SetActive(true);
	}
}
