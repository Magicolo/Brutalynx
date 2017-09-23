using UnityEngine;
using UnityEngine.UI;

public enum Mushrooms
{
	Red,
	Green,
	Yellow,
	Blue
}

public class Mushroom : MonoBehaviour
{
	public Mushrooms Type;
	public Button Button;

	void Update()
	{
		Button.enabled = StoryManager.Instance.Current.IsAvailable(Type);
	}

	public void OnClick()
	{
		StoryManager.Instance.Select(Type);
	}
}
