using UnityEngine;
using UnityEngine.UI;

public class UIStateBar : MonoBehaviour
{

	public Text TextName;
	public Scrollbar ScrollLeft;
	public Scrollbar ScrollRight;

	public Traits status;

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
			case Traits.Confidence:
				SetState(PlayerManager.Instance.Confidence);
				break;
			case Traits.Happiness:
				SetState(PlayerManager.Instance.Happiness);
				break;
			case Traits.Alertness:
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
