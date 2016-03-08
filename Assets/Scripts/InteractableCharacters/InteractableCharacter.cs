using UnityEngine;
using System.Collections;

public class InteractableCharacter : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Interaction() {
		TextManager.SpawnTextBox("<color=cyan>I'm</color> <color=purple>a</color> <color=red>rock</color> <size=150>OMG this works!</size> Hahaha I can't believe it!");
		if (spriteRenderer.color == Color.red) {
			spriteRenderer.color = Color.blue;
		} else {
			spriteRenderer.color = Color.red;
		}
	}
}
