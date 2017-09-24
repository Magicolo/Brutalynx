using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public Boss[] Bosses;

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

