using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehaviour
{

	public Text TextName;
	public Scrollbar ScrollLeft;
	public Scrollbar ScrollRight;

	public Status status;

	public Image HandleLeft;
	public Image HandleRight;

	public Color Left = Color.red;
	public Color Right = Color.green;

	public float StateValue;
	public string StateName;

	public void Init()
	{
		TextName.text = StateName;
		HandleLeft.color = Left;
		HandleRight.color = Right;
	}

	private void Awake()
	{
		Init();
	}

	public void SetState(double stateValue)
	{
		float value = Mathf.Clamp((float)stateValue, -1f, 1f);

		ScrollLeft.size = -value;
		ScrollRight.size = value;

	}

	private void Update()
	{
		switch (status)
		{
			case Status.Confidence:
				SetState(PlayerManager.Instance.Confidence);
				break;
			case Status.Happiness:
				SetState(PlayerManager.Instance.Happiness);
				break;
			case Status.Alertness:
				SetState(PlayerManager.Instance.Alertness);
				break;
		}
	}

	private void OnValidate()
	{
		SetState(StateValue);
		Init();
	}

}
