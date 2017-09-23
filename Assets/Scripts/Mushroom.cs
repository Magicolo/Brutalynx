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

	public void OnClick()
	{
		MushroomManager.Instance.Consume(Type);
	}
}
