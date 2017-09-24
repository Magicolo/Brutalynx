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

	public Gradient colorGradient;

	public Color Current;

	public string StateName;

	public float StateValue;
	public float StateDestination;
	public float Speed;


	public void Init()
	{
		TextName.text = StateName;
	}

	private void Start()
	{
		Init();
	}

	private void Awake()
	{
		Init();
	}

	public void SetState(float stateValue)
	{
		StateDestination = Mathf.Clamp(stateValue, -1f, 1f);
	}

	public float CalculPourcent(float min, float max, float abs)
	{
		return (abs - min) / (max - min);
	}

	private void Update()
	{
		SetState(PlayerManager.Instance.GetTraitValue(status));
		StateValue = Mathf.Lerp(StateValue, StateDestination, Time.deltaTime * Speed);

		float abs = Mathf.Abs(StateValue);

		Current = colorGradient.Evaluate(abs);

		ScrollLeft.size = -StateValue;
		ScrollRight.size = StateValue;
		HandleLeft.color = Current;
		HandleRight.color = Current;
	}

	private void OnValidate()
	{
		Init();
	}

}
