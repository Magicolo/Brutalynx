using System;
using UnityEngine.UI;

public class Flash : Singleton<Flash>
{
	public Image Image;

	void Start()
	{
		FadeOut(() => { });
	}

	public void FadeIn(Action done)
	{

	}

	public void FadeOut(Action done)
	{

	}

}
