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
		var isWaiting = MushroomManager.Instance.IsWaiting;
		var scale = MushroomManager.Instance.IsWaiting ? Vector3.one : Vector3.zero;
		transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * 5f);
		Button.enabled = isWaiting;
	}

	public void OnClick()
	{
		MushroomManager.Instance.Consume(Type);
	}
}
