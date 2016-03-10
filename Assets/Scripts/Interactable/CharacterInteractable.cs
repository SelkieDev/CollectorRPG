using UnityEngine;
using System.Collections;

public class CharacterInteractable : MonoBehaviour {

	public string textToBeDisplayed;  //This string will show up in the dialog box that spawns when the player interacts with this object or character.
	SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Interaction() {
		TextManager.SpawnCharacterBox(textToBeDisplayed, spriteRenderer.sprite);
	}
}
