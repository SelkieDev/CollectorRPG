using UnityEngine;
using System.Collections;

public class InteractableCharacter : MonoBehaviour {

	public void Interaction() {
		TextManager.SpawnTextBox("<color=cyan>I'm</color> <color=purple>a</color> <color=red>rock</color> <size=150>OMG this works!</size> Hahaha I can't believe it!");
	}
}
