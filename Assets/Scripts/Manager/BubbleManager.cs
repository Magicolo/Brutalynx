using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
	public GameObject prefabs;

<<<<<<< b707711ccadad04ff77566c2a2a845155fbe47b5
	public void Spawn(float width, float height, string textToWrite, float speed, float timeBeforeHidding, GameObject attachTo, bool left)
    {
=======
	public GameObject Spawn(string textToWrite, float speed, float timeBeforeHidding, GameObject attachTo, float width, float height, bool leftBubble)
	{
>>>>>>> 03128ceb75682806e0ff7a0e9a501e0caead39cf
		var newBubble = Instantiate(prefabs);

<<<<<<< b707711ccadad04ff77566c2a2a845155fbe47b5
        newBubble.transform.SetParent(attachTo.transform);
        newBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        newBubble.GetComponent<RectTransform>().localScale = Vector3.one;
        newBubble.GetComponent<RectTransform>().position = new Vector3(30,30,0);

        print(newBubble.GetComponent<RectTransform>().position);
        print(newBubble.transform.position);


        newBubble.transform.SetParent(UIManager.Instance.Canvas.transform);

        print(newBubble.GetComponent<RectTransform>().position);

        newBubble.GetComponent<UIBubbleText>().Init(width, height, textToWrite, speed, timeBeforeHidding, left);

        print(newBubble.GetComponent<RectTransform>().position);

        newBubble.GetComponent<UIBubbleText>().LaunchBubble();

        print(newBubble.transform.position);
    }
=======
		newBubble.GetComponent<UIBubbleText>().Init(textToWrite, speed, timeBeforeHidding, leftBubble);
		newBubble.GetComponent<UIBubbleText>().LaunchBubble();

		return newBubble;
	}
>>>>>>> 03128ceb75682806e0ff7a0e9a501e0caead39cf
}
