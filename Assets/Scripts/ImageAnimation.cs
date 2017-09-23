using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
	public Sprite[] Sprites;
	public Image Image;
	public double Speed;

    private void OnEnable()
    {
		StartCoroutine(AnimationRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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
