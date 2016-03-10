using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public GameObject textBoxHelper, characterTextBoxHelper;
	static GameObject textBox, characterBox;
    static Transform canvasTransform;

    static RectTransform textSpawn, characterTextSpawn;

    void Start() {
        canvasTransform = GameObject.FindWithTag("Canvas").transform;

        textBox = textBoxHelper;
        characterBox = characterTextBoxHelper;

        textSpawn = GameObject.FindWithTag("TextBoxSpawn").GetComponent<RectTransform>();
        characterTextSpawn = GameObject.FindWithTag("CharacterTextBoxSpawn").GetComponent<RectTransform>();

        textBox = Instantiate(textBox, textSpawn.anchoredPosition, textSpawn.rotation) as GameObject;
        characterBox = Instantiate(characterBox, characterTextSpawn.anchoredPosition, characterTextSpawn.rotation) as GameObject;

        textBox.transform.SetParent(canvasTransform, false);
        characterBox.transform.SetParent(canvasTransform, false);

        textBox.SetActive(false);
        characterBox.SetActive(false);
    }

    /** Spawns a character box and types TEXT at one character per SPEED seconds.
      * All other classes should call this function and not TypeText. */
    public static void SpawnCharacterBox(string text, Sprite sprite, float speed = 0.04f) {
        CloseActiveTextBoxes();
        characterBox.SetActive(true);
        characterBox.GetComponent<TextBox>().TypeText(text, speed, sprite);
    }

    /** Spawns a text box and types TEXT at one character per SPEED seconds.
      * All other classes should call this function and not TypeText. */
    public static void SpawnTextBox(string text, float speed = 0.04f) {
        CloseActiveTextBoxes();
        textBox.SetActive(true);
        textBox.GetComponent<TextBox>().TypeText(text, speed);
    }

    /** Closes all active text boxes. */
    public static void CloseActiveTextBoxes() {
        textBox.SetActive(false);
        characterBox.SetActive(false);
    }
}
