using UnityEngine;

public enum Characters
{
	Player,
	NPC
}

public class DialogManager : Singleton<DialogManager>
{
	public Dialog PlayerDialog;
	public Dialog NPCDialog;

	public Dialog Spawn(string[] lines, Vector3 position, Characters character, CharacterType type, Boss.Statuses ?status = null)
	{
		var dialog = Instantiate(GetPrefab(character), position, Quaternion.identity, UIManager.Instance.Canvas.transform);
		dialog.Display(type, status, lines);

		return dialog;
	}

	Dialog GetPrefab(Characters character)
	{
		switch (character)
		{
			case Characters.Player: return PlayerDialog;
			default:
			case Characters.NPC: return NPCDialog;
		}
	}
}
