using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	public Text Text;

	void Update()
	{
		Text.text = TimelineManager.Instance.Time.Hours + ":" + TimelineManager.Instance.Time.Minutes;
	}
}
