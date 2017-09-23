using UnityEngine;
using System.Collections;
using Utils.UI;
using System.Collections.Generic;

public class UIContextMenu : UIPanel
{
    public List<ChoiceData> choices = new List<ChoiceData>();
    public UITimeLine timeLine;

    public void Init(List<ChoiceData> choices)
    {
        Hide();
        this.choices = choices;
    }

    public void LaunchContext()
    {

    }
}
