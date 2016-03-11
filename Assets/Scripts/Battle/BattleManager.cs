using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	public Transform friendlySpawnHelper, enemySpawnHelper;
	static Transform friendlySpawn, enemySpawn;

	static GameObject[] playerParty;
	static GameObject[] enemyParty;

	void Start() {
		friendlySpawn = friendlySpawnHelper;
		enemySpawn = enemySpawnHelper;
	}

	/** Going to use resources.load to get prefabs and then set their appropriate values. */

	public static void SetPlayerParty(GameObject[] playersParty) {
		playerParty = playersParty;
	}

	public static void SetEnemyParty(GameObject[] enemysParty) {
		enemyParty = enemysParty;
	}

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			friendlySpawn = friendlySpawnHelper;
			enemySpawn = enemySpawnHelper;
			foreach (GameObject member in playerParty) {
				Instantiate(member, friendlySpawn.position, friendlySpawn.rotation);
			}
			foreach (GameObject member in enemyParty) {
				Instantiate(member, friendlySpawn.position, friendlySpawn.rotation);
			}
		}
	}

	public static void StartBattle() {
		SceneManager.LoadScene("Battle");
		PlayerMovement.canMove = true;
	}
}
