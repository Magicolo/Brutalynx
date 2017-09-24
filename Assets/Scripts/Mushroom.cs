using UnityEngine;
using UnityEngine.UI;

public enum Mushrooms
{
	PsilocybinCubensis_1 = 1,
	PluteusSalicinus_2 = 2,
	GymnopilusLuteoviridis_3 = 3,
	PanaeolusCinctulus_4 = 4,
	InocybeCoelestium_5 = 5,
	ConocybeKuehneriana_6 = 6,
	PsilocybinSemilanceata_7 = 7,
	PanaeolusSubbalteatus_8 = 8,
	InocybeHaemacta_9 = 9,
	ConocybeCyanopus_10 = 10,
	GymnopilusValidipes_11 = 11,
	PluteusBrunneidiscus_12 = 12,
	CopelandiaBispora_13 = 13,
	GymnopilusAeruginosus_14 = 14,
	InfinitusFractaliosis_15 = 15
}

public class Mushroom : MonoBehaviour
{
	public Mushrooms Type;
	public Button Button;

	void Update()
	{
		var isWaiting = MushroomManager.Instance.IsWaiting;
		var scale = MushroomManager.Instance.IsWaiting ? Vector3.one : Vector3.zero;
		transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * 5f);
		Button.enabled = isWaiting;
	}

	public void OnClick()
	{
		MushroomManager.Instance.Consume(Type);
	}
}
