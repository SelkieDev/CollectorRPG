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
    }

    /** Spawns a text box and types TEXT at one character per SPEED seconds.
      * All other classes should call this function and not TypeText. */
    public static void SpawnTextBox(string text, float speed = 0.1f) {
        newTextBox.SetActive(true);
        newTextBox.GetComponent<TextBox>().TypeText(text, speed);
    }
}
