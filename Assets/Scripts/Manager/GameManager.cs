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
			StartCoroutine(VomitRoutine());
		}
	}

	void OnEnable()
	{
		StartCoroutine(GameRoutine());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene("Title");
	}

	IEnumerator VomitRoutine()
	{
		Dude.Instance.SetState(Dude.States.Vomitting);
		yield return new WaitForSeconds(1.25f);
		Flash.Instance.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
	}

	IEnumerator GameRoutine()
	{
		yield return new WaitForSeconds(2f);

		foreach (var boss in Bosses)
		{
			yield return new WaitForSeconds(3f);
			var instance = Instantiate(boss, Door.Instance.transform.position, Quaternion.identity, UIManager.Instance.bossRoot.transform);

			while (!instance.IsDone)
				yield return null;

			PlayerManager.Instance.ResetTraits();
			Destroy(instance);
		}
	}
}

