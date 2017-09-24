using System;
using System.Collections.Generic;

public class MushroomManager : Singleton<MushroomManager>
{
	public bool IsWaiting;
	public readonly Stack<Mushrooms> History = new Stack<Mushrooms>();

	Action<Mushrooms> listener = m => { };

	public void Consume(Mushrooms mushroom)
	{
		// Add constant shroom effects.
		switch (mushroom)
		{
			case Mushrooms.PsilocybinCubensis_1:
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.PluteusSalicinus_2:
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.GymnopilusLuteoviridis_3:
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.PanaeolusCinctulus_4:
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.InocybeCoelestium_5:
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.ConocybeKuehneriana_6:
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.PsilocybinSemilanceata_7:
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.PanaeolusSubbalteatus_8:
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.InocybeHaemacta_9:
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.ConocybeCyanopus_10:
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.GymnopilusValidipes_11:
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Happiness -= 0.5f;
				break;
			case Mushrooms.PluteusBrunneidiscus_12:
				PlayerManager.Instance.Irritability += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.CopelandiaBispora_13:
				PlayerManager.Instance.Happiness += 0.5f;
				PlayerManager.Instance.Confidence -= 0.5f;
				break;
			case Mushrooms.GymnopilusAeruginosus_14:
				PlayerManager.Instance.Confidence += 0.5f;
				PlayerManager.Instance.Irritability -= 0.5f;
				break;
			case Mushrooms.InfinitusFractaliosis_15:
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
	}

	public void WaitConsumption(Action<Mushrooms> consumed)
	{
		listener += consumed;
		IsWaiting = true;
	}
}

