using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public Boss[] Bosses;

	public void CheckPlayer()
	{
		if (Mathf.Abs(PlayerManager.Instance.Confidence) >= 1f ||
			Mathf.Abs(PlayerManager.Instance.Irritability) >= 1f ||
			Mathf.Abs(PlayerManager.Instance.Happiness) >= 1f)
		{
			Flash.Instance.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
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
			var instance = Instantiate(boss, Door.Instance.transform.position, Quaternion.identity, UIManager.Instance.bossRoot.transform);

			while (!instance.IsDone)
				yield return null;

			PlayerManager.Instance.ResetTraits();
			Destroy(instance);
		}
	}
}

