using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public Boss[] Bosses;

	public void CheckPlayer()
	{
		if (Mathf.Abs(PlayerManager.Instance.Confidence) >= 1f ||
			Mathf.Abs(PlayerManager.Instance.Irritability) >= 1f ||
			Mathf.Abs(PlayerManager.Instance.Happiness) >= 1f)
		{

		}
	}

	void OnEnable()
	{
		StartCoroutine(GameRoutine());
	}

	IEnumerator GameRoutine()
	{
		foreach (var boss in Bosses)
		{
			yield return new WaitForSeconds(2f);
			var instance = Instantiate(boss, Door.Instance.transform.position, Quaternion.identity, UIManager.Instance.Canvas.transform);

			while (!instance.IsDone)
				yield return null;

			Destroy(instance);
		}
	}
}

