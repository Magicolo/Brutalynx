using UnityEngine;

public class Singleton<TSelf> : MonoBehaviour where TSelf : Singleton<TSelf>
{
	public static TSelf Instance
	{
		get
		{
			if (_instance == null) _instance = FindObjectOfType<TSelf>();
			return _instance;
		}
	}

	static TSelf _instance;

	protected virtual void Awake() { _instance = this as TSelf; }
	protected virtual void OnEnable() { _instance = this as TSelf; }
	protected virtual void Start() { _instance = this as TSelf; }
}
