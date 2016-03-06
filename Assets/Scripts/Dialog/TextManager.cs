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
    	SpawnTextBox(spawn, "<color=cyan>What</color> the fuck? What the <i>fuck?</i> What the fuck? What the <color=magenta>fuck</color>? What the fuck? What the fuck?", .04f);
    }
}
