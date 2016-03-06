using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class util : MonoBehaviour {

	public static GameObject FindNearestObject(GameObject player, List<GameObject> possibleObjects) {
		GameObject closestObject = null;
		float closestObjectDistance = 99999f;
		foreach (GameObject possibleObject in possibleObjects) {
			float distance = Vector2.Distance(player.transform.position, possibleObject.transform.position);
			if (distance < closestObjectDistance) {
				closestObjectDistance = distance;
				closestObject = possibleObject;
			}
		}
		return closestObject;
	}
}
