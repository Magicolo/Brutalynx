using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMushroom : MonoBehaviour {
    public Mushroom[] allMushrooms;
    public List<Mushroom> activeMushrooms = new List<Mushroom>();

    public void SetActive(List<Mushroom> m)
    {
        this.activeMushrooms = m;
    }

    public void Init()
    {
        allMushrooms = FindObjectsOfType<Mushroom>();
    }

    private void Update()
    {
        foreach (Mushroom m in allMushrooms)
            m.enabled = false;

        foreach (Mushroom m in activeMushrooms)
            m.enabled = true;
    }

    private void OnValidate()
    {
        Init();
        foreach (Mushroom m in allMushrooms)
            m.gameObject.SetActive(false);

        foreach (Mushroom m in activeMushrooms)
            m.gameObject.SetActive(true);
    }
}
