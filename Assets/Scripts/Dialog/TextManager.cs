using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	public GameObject textBox;
    public Transform canvas;

    public RectTransform spawn;

    public void SpawnTextBox(RectTransform location, string text, float dialogSpeed) {
        GameObject newTextBox = Instantiate(textBox, location.anchoredPosition, location.rotation) as GameObject;
        newTextBox.GetComponent<TextBox>().TypeText(text, dialogSpeed);
        newTextBox.transform.SetParent(canvas, false);
    }

    void Start() {
    	SpawnTextBox(spawn, "<color=cyan>Please</color> work. <color=purple>Please</color> work. <color=teal>Please</color> work. <color=red>Please</color> work. ", .1f);
    }
}
