using System;
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
	public Text Text;
	public Image ImageBubble;

	private int caracterToWrite;

	public bool left;

	public void Init(string textToWrite, float speed, float timeBeforeHidding, bool left)
	{
		CancelInvoke();
		Hide();
		this.textToWrite = textToWrite;
		this.speed = speed;
		this.timeBeforeHidding = timeBeforeHidding;

		ImageBubble.transform.localScale = (new Vector3((left) ? 1 : -1, 1, 1));

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
		Text.text = textToWrite.Substring(0, caracterToWrite);
	}
}
