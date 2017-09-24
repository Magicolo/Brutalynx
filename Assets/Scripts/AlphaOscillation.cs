using UnityEngine;
using UnityEngine.UI;

public class AlphaOscillation : MonoBehaviour
{
	public float Frequency = 2f;
	public float Amplitude = 0.25f;
	public float Center = 1f;
	public Image Image;

	void Update()
	{
		var color = Image.color;
		var sine = Mathf.Sin(Time.time * Frequency + (GetHashCode() % 100)) * Amplitude + Center;
		color.a = sine;
		Image.color = color;
	}
}

