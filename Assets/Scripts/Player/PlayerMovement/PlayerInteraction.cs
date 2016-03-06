using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour {

	List<GameObject> interactablesInRange = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
		if (PlayerInput.interactPressed) {
			GameObject nearestInteractable = util.FindNearestObject(this.gameObject, interactablesInRange);
			if (nearestInteractable != null) {
				nearestInteractable.SendMessage("Interaction");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "InteractableCharacter") {
			//Debug.Log("Added Rock");
			interactablesInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "InteractableCharacter") {
			//Debug.Log("Removed Rock");
			interactablesInRange.Remove(other.gameObject);
		}
	}
}
