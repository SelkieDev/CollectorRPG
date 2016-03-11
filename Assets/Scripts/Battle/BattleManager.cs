using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

	public static void StartBattle() {
		Debug.Log("Consider this battle started.");
		PlayerMovement.canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
