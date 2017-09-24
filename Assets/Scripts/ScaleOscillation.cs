using UnityEngine;

public class ScaleOscillation : MonoBehaviour
{
	public float Frequency = 2f;
	public float Amplitude = 0.25f;
	public float Center = 1f;

	void Update()
	{
		var sine = Mathf.Sin(Time.time * Frequency + GetHashCode()) * Amplitude + Center;
		var scale = Vector3.one * sine;
		transform.localScale = scale;
	}
}

