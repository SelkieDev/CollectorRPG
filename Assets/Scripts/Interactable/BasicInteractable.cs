using UnityEngine;
using System.Collections;

public class BasicInteractable : MonoBehaviour {

	public string textToBeDisplayed;  //This string will show up in the dialog box that spawns when the player interacts with this object or character.
	SpriteRenderer spriteRenderer;

	public void Interaction() {
		//PlayerMovement.canMove = false;
		TextManager.SpawnTextBox(textToBeDisplayed);
	}
}
