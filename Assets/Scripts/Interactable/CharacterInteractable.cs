using UnityEngine;
using System.Collections;

public class CharacterInteractable : MonoBehaviour {

	/** The string that will be displayed in the dialog box. */
	public string textToBeDisplayed;

	/** The sprite that will be displayed on the dialog box. */
	Sprite sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}

	public void Interaction(GameObject player) {
		TextManager.SpawnCharacterBox(textToBeDisplayed, sprite);
	}
}
