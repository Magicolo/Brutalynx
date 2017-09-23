using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<TSelf> : MonoBehaviour where TSelf : Singleton<TSelf>
{
	public static TSelf Instance { get; private set; }

	protected virtual void Awake() { Instance = this as TSelf; }
}
