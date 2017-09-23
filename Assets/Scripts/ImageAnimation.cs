using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
	public Sprite[] Sprites;
	public Image Image;
	public double Speed;

	void Start()
	{
		StartCoroutine(AnimationRoutine());
	}

	IEnumerator AnimationRoutine()
	{
		yield return null;
		yield return null;
		yield return null;

		var index = 0;
		while (true)
		{
			Image.sprite = Sprites[index++ % Sprites.Length];
			yield return new WaitForSeconds((float)(Time.deltaTime / Speed));
		}
	}
}
