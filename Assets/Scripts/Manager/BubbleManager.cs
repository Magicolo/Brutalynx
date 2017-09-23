using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
	public GameObject prefabs;

	public GameObject Spawn(string textToWrite, float speed, float timeBeforeHidding, GameObject attachTo, float width, float height, bool leftBubble)
	{
		var newBubble = Instantiate(prefabs);

		newBubble.transform.SetParent(attachTo.transform);
		newBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
		newBubble.GetComponent<RectTransform>().localScale = Vector3.one;
		newBubble.GetComponent<RectTransform>().position = new Vector3(30, 30, 0);

		print(newBubble.GetComponent<RectTransform>().position);
		print(newBubble.transform.position);


		newBubble.transform.SetParent(UIManager.Instance.Canvas.transform);

		print(newBubble.GetComponent<RectTransform>().position);

		//newBubble.GetComponent<UIBubbleText>().Init(width, height, textToWrite, speed, timeBeforeHidding, left);

		print(newBubble.GetComponent<RectTransform>().position);

		newBubble.GetComponent<UIBubbleText>().LaunchBubble();

		print(newBubble.transform.position);
		//newBubble.GetComponent<UIBubbleText>().Init(textToWrite, speed, timeBeforeHidding, leftBubble);
		newBubble.GetComponent<UIBubbleText>().LaunchBubble();

		return newBubble;
	}
}
