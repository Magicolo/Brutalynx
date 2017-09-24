using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFlicker : MonoBehaviour {

    public Image img;
    private Color color;

    private void Start()
    {
        img = GetComponent<Image>();
        color = img.color;
    }
    // Update is called once per frame
    void Update () {

        color.a += (Random.value - 0.5f) * 0.5f;
        color.a = Mathf.Clamp(color.a, 0.5f, 1);
        img.color = color;
	}
}
