using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : Singleton<TitleManager>
{
	public GameObject Credits;
	public GameObject Instructions;

	public void OnDemarrer()
	{
		SceneManager.LoadScene("Main");
	}

	public void OnCredits()
	{
		Credits.SetActive(true);
	}

	public void OnInstructions()
	{
		Instructions.SetActive(true);
	}

	public void OnExit()
	{
		Application.Quit();
	}

	void Update()
	{
		if (Credits.activeSelf && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))) Credits.SetActive(false);
		if (Instructions.activeSelf && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))) Instructions.SetActive(false);
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}
}
