using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	static GameObject[] playerParty;
	static GameObject[] enemyParty;

	/** Going to use resources.load to get prefabs and then set their appropriate values. */

	public static void SetPlayerParty(GameObject[] playersParty) {
		playerParty = playersParty;
	}

	public static void SetEnemyParty(GameObject[] enemysParty) {
		enemyParty = enemysParty;
	}

	public static void StartBattle() {
		SceneManager.LoadScene("Battle");
		PlayerMovement.canMove = true;
	}
}
