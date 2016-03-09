using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public GameObject textBoxHelper, characterTextBoxHelper;
    //public Sprite[] characterImages;
    private Sprite sprite;
	static GameObject textBox, characterTextBox;
    static Transform canvasTransform;
    static GameObject newTextBox, newCharacterTextBox;

    static RectTransform textSpawn, characterTextSpawn;

    void Start() {
        textBox = textBoxHelper;
        characterTextBox = characterTextBoxHelper;
        canvasTransform = GameObject.FindWithTag("Canvas").transform;
        textSpawn = GameObject.FindWithTag("TextBoxSpawn").GetComponent<RectTransform>();
        characterTextSpawn = GameObject.FindWithTag("CharacterTextBoxSpawn").GetComponent<RectTransform>();
        newTextBox = Instantiate(textBox, textSpawn.anchoredPosition, textSpawn.rotation) as GameObject;
        newCharacterTextBox = Instantiate(characterTextBox, characterTextSpawn.anchoredPosition, characterTextSpawn.rotation) as GameObject;
        newTextBox.transform.SetParent(canvasTransform, false);
        newTextBox.SetActive(false);
        newCharacterTextBox.transform.SetParent(canvasTransform, false);
        newCharacterTextBox.SetActive(false);
    }

    /** Spawns a text box and types TEXT at one character per SPEED seconds.
      * All other classes should call this function and not TypeText. */
    public static void SpawnCharacterTextBox(string text, float speed = 0.04f) {
        CloseActiveTextBoxes();
        newCharacterTextBox.SetActive(true);
       // newCharacterTextBox.Find("Character Image").GetComponent<Image>().sprite = characterImages[characterCode];
        newCharacterTextBox.GetComponent<TextBox>().TypeText(text, speed);
    }

    public static void SpawnTextBox(string text, float speed = 0.04f) {
        CloseActiveTextBoxes();
        newTextBox.SetActive(true);
        newTextBox.GetComponent<TextBox>().TypeText(text, speed);
    }

    public static void CloseActiveTextBoxes() {
        newTextBox.SetActive(false);
        newCharacterTextBox.SetActive(false);
    }
}
