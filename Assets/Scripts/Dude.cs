using System;

public class Dude : Singleton<Dude>
{
	public void Speak(string[] lines, Action done = null)
	{
		var dialog = DialogManager.Instance.Spawn(lines, transform.position, Characters.Player);
		dialog.OnDespawned += done;
	}
}

