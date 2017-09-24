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
	public int Index;
	public Button Button;

	void Awake()
	{
		transform.localScale = Vector3.zero;
	}

	void Update()
	{
		var isEnabled = MushroomManager.Instance.IsWaiting && Index < MushroomManager.Instance.AvailableMushrooms.Length;
		var scale = isEnabled ? Vector3.one : Vector3.zero;
		transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * 5f);
		Button.enabled = isEnabled;

		if (isEnabled)
		{
			var mushroom = MushroomManager.Instance.AvailableMushrooms[Index];
			Button.image.sprite = MushroomManager.Instance.MushroomSprites[(int)mushroom];
		}
	}

	public void OnClick()
	{
		MushroomManager.Instance.Consume(Index);
	}
}
