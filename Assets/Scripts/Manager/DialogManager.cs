using UnityEngine;

public class DialogManager : Singleton<DialogManager>
{
	public Dialog Prefab;

	public Dialog Spawn(string text, Vector3 position)
	{
		var dialog = Instantiate(Prefab, position, Quaternion.identity, UIManager.Instance.Canvas.transform);
		dialog.Display(text);

		return dialog;
	}
}
