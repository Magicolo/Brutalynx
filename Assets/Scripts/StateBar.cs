using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehaviour {

    public Text TextName;
    public Scrollbar ScrollLeft;
    public Scrollbar ScrollRight;

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

    public void SetState(float stateValue)
    {
        ScrollLeft.size = -stateValue;
        ScrollRight.size = stateValue;
    }


    private void OnValidate()
    {
        SetState(StateValue);
        Init();
    }

}
