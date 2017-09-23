using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(LayoutElement))]
[RequireComponent(typeof(Button))]
public class UIContextChoice : MonoBehaviour
{
    public Text text;
    public Button button;

    public void Init(string text, Action action, Action hide)
    {
        this.text.text = text;
        this.button.onClick.AddListener( () => action() );
        this.button.onClick.AddListener( () => hide() );
    }
}
