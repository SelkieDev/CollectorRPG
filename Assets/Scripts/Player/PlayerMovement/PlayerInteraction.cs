using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour {

	List<GameObject> interactablesInRange = new List<GameObject>();
	
	void Update () {
		if (PlayerInput.interactPressed) {
			GameObject nearestInteractable = util.FindNearestObject(this.gameObject, interactablesInRange);
			if (nearestInteractable != null) {
				nearestInteractable.SendMessage("Interaction", gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "InteractableCharacter") {
			interactablesInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "InteractableCharacter") {
			interactablesInRange.Remove(other.gameObject);
		}
	}
}
