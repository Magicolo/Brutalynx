using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.UI;

[Serializable]
[RequireComponent(typeof(Text))]
public class UIBubbleText : UIPanel
{

    public string textToWrite;
    public float speed = 0.5f;
    public float timeBeforeHidding;
    public UnityEvent OnHidding = new UnityEvent();
    public UnityEvent OnStarting = new UnityEvent();

    private int caracterToWrite;
    private Text text;
    private Image imageBubble;

    public bool left;

    public void Init(string textToWrite, float speed, float timeBeforeHidding, bool left)
    {
        CancelInvoke();
        Hide();
        this.textToWrite = textToWrite;
        this.speed = speed;
        this.timeBeforeHidding = timeBeforeHidding;

        imageBubble.transform.localScale = (new Vector3((left)?1:-1, 1, 1));

        caracterToWrite = 0; 
    }

    public void LaunchBubble()
    {
        Show();
        InvokeRepeating("AddCharacter", 0, speed);
        OnStarting.Invoke();
    }

    protected override void Start()
    {
        base.Start();
        text = GetComponent<Text>();
        imageBubble = GetComponentInChildren<Image>();
        Init(textToWrite, speed, timeBeforeHidding, left);
        LaunchBubble();
    }

    public void AddCharacter()
    {
        if (caracterToWrite < textToWrite.Length)
            caracterToWrite++;
        else
        {
            CancelInvoke();
            OnHidding.Invoke();
        }
        UpdateText();
    }

    public void DestroyBubble()
    {
        Destroy(this.gameObject);
    }

    public void UpdateText()
    {
        text.text = textToWrite.Substring(0, caracterToWrite);
    }
}
