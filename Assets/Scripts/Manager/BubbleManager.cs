using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
	public GameObject prefabs;

	public void Spawn(string textToWrite, float speed, float timeBeforeHidding, GameObject attachTo, float width, float height, bool leftBubble)
	{
		var newBubble = Instantiate(prefabs);
		newBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
		newBubble.transform.position = attachTo.transform.position;
		newBubble.transform.SetParent(attachTo.transform);

		newBubble.GetComponent<UIBubbleText>().Init(textToWrite, speed, timeBeforeHidding, leftBubble);
		newBubble.GetComponent<UIBubbleText>().LaunchBubble();
	}
}
