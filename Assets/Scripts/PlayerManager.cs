﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance { get; private set; }

	public float Drunkness;
	public float Happiness;
	public float Boredom;

	void Awake()
	{
		Instance = this;
	}
}