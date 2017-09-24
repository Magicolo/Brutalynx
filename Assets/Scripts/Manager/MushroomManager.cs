using System;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager : Singleton<MushroomManager>
{
	public bool IsWaiting;
	public readonly Stack<Mushrooms> History = new Stack<Mushrooms>();
	public Sprite[] MushroomSprites;
	public Mushrooms[] AvailableMushrooms = new Mushrooms[0];

	Action<Mushrooms> listener = m => { };

	public void Consume(int index) { Consume(AvailableMushrooms[index]); }

	public void Consume(Mushrooms mushroom)
	{
		// Add constant shroom effects.
		switch (mushroom)
		{
			case Mushrooms.PsilocybinCubensis_1:
				if (PlayerManager.Instance.IsStatus(Statuses.Terreur)) PlayerManager.Instance.Irritability -= 0.5f;
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.PluteusSalicinus_2:
				if (PlayerManager.Instance.IsStatus(Statuses.Rage)) PlayerManager.Instance.Happiness -= 0.5f;
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.GymnopilusLuteoviridis_3:
				if (PlayerManager.Instance.IsStatus(Statuses.Tristesse)) PlayerManager.Instance.Confidence -= 0.5f;
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.PanaeolusCinctulus_4:
				if (PlayerManager.Instance.IsStatus(Statuses.Extase)) PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.InocybeCoelestium_5:
				if (PlayerManager.Instance.IsStatus(Statuses.Narcissique)) PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.ConocybeKuehneriana_6:
				if (PlayerManager.Instance.IsStatus(Statuses.Fanatisme)) PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.PsilocybinSemilanceata_7:
				if (PlayerManager.Instance.IsStatus(Statuses.Narcissique)) PlayerManager.Instance.Confidence -= 0.5f;
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.PanaeolusSubbalteatus_8:
				if (PlayerManager.Instance.IsStatus(Statuses.Fanatisme)) PlayerManager.Instance.Irritability -= 0.5f;
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.InocybeHaemacta_9:
				if (PlayerManager.Instance.IsStatus(Statuses.Extase)) PlayerManager.Instance.Happiness -= 0.5f;
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.ConocybeCyanopus_10:
				if (PlayerManager.Instance.IsStatus(Statuses.Tristesse)) PlayerManager.Instance.Happiness -= 1f;
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.GymnopilusValidipes_11:
				if (PlayerManager.Instance.IsStatus(Statuses.Terreur)) PlayerManager.Instance.Confidence -= 1f;
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.PluteusBrunneidiscus_12:
				if (PlayerManager.Instance.IsStatus(Statuses.Rage)) PlayerManager.Instance.Irritability -= 1f;
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.CopelandiaBispora_13:
				if (PlayerManager.Instance.IsStatus(Statuses.Narcissique)) PlayerManager.Instance.Confidence -= 0.25f;
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.GymnopilusAeruginosus_14:
				if (PlayerManager.Instance.IsStatus(Statuses.Fanatisme)) PlayerManager.Instance.Irritability -= 0.25f;
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.InfinitusFractaliosis_15:
				if (PlayerManager.Instance.IsStatus(Statuses.Extase)) PlayerManager.Instance.Happiness -= 0.25f;
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			default:
				break;
		}

		History.Push(mushroom);
		IsWaiting = false;
		listener(mushroom);
		listener = m => { };
		GameManager.Instance.CheckPlayer();
	}

	public void WaitConsumption(Action<Mushrooms> consumed)
	{
		listener += consumed;
		IsWaiting = true;
	}
}

