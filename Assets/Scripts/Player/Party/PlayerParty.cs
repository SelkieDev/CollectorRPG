using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : MonoBehaviour {

	public List<GameObject> playerParty = new List<GameObject>();
	
	public GameObject[] getParty() {
		return playerParty.ToArray();
	}

	public void PrepareForBattle() {
		BattleManager.SetPlayerParty(getParty());
	}
}
