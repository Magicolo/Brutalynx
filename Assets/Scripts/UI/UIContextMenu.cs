using UnityEngine;
using Utils.UI;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(Button))]
public class UIContextMenu : UIPanel
{
    public List<ChoiceData> choices = new List<ChoiceData>();
    public UIContextChoice prefabsChoice;
    public GridLayoutGroup grid;

    public void Init(float width, float height, List<ChoiceData> choices)
    {
        Hide();
        grid.cellSize = new Vector2(width, height);
        this.choices = choices;
        foreach (ChoiceData choice in choices)
        {
            UIContextChoice p = Instantiate(prefabsChoice);
            p.transform.position = Vector3.zero;
            p.Init(choice.text, choice.onClick, Destroy);
            p.transform.SetParent(this.transform);
        }
    }

    public void Destroy()
    {
        DestroyObject(this.gameObject);
    }

    protected override void Start()
    {
        base.Start();
        Init(100, 100, choices);
        Show();
    }
}
