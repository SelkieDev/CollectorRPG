using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

    public GameObject textBoxHelper;
	static GameObject textBox;
    static Transform canvasTransform;
    static GameObject newTextBox;

    static RectTransform spawn;

    void Start() {
        textBox = textBoxHelper;
        canvasTransform = GameObject.FindWithTag("Canvas").transform;
        spawn = GameObject.FindWithTag("TextBoxSpawn").GetComponent<RectTransform>();
        newTextBox = Instantiate(textBox, spawn.anchoredPosition, spawn.rotation) as GameObject;
        newTextBox.transform.SetParent(canvasTransform, false);
        newTextBox.SetActive(false);
        //SpawnTextBox("<color=cyan>Please</color> work. <color=purple>Please</color> work. <color=teal>Please</color> work. <color=red>Please</color> work. ", .1f);
    }

    public static void SpawnTextBox(string text, float dialogSpeed = 0.2f) {
        newTextBox.SetActive(true);
        newTextBox.GetComponent<TextBox>().TypeText(text, dialogSpeed);
    }
}
