using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyInteractable : MonoBehaviour {

	/** The string that will be displayed in the dialog box. */
	public string textToBeDisplayed;

	/** The sprite that will be displayed on the dialog box. */
	Sprite sprite;

	public List<GameObject> enemiesInGroup = new List<GameObject>();

	void Start() {
		sprite = GetComponent<SpriteRenderer>().sprite;
		enemiesInGroup.Add(gameObject);
	}

	public void Interaction(GameObject player) {
		player.SendMessage("PrepareForBattle");
		StartCoroutine("PrepareForBattle");
	}

	IEnumerator PrepareForBattle() {
		TextManager.SpawnCharacterBox(textToBeDisplayed, sprite);
		PlayerMovement.canMove = false;
		BattleManager.SetEnemyParty(enemiesInGroup.ToArray());
		yield return new WaitForSeconds(2);
		BattleManager.StartBattle();
	}
}
