using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyInteractable : MonoBehaviour {

	/** The string that will be displayed in the dialog box. */
	public string textToBeDisplayed;

	/** The sprite that will be displayed on the dialog box. */
	Sprite sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}

	public void Interaction() {
		StartCoroutine("StartBattle");
	}

	IEnumerator StartBattle() {
		TextManager.SpawnCharacterBox(textToBeDisplayed, sprite);
		PlayerMovement.canMove = false;
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Battle");
		BattleManager.StartBattle();
	}
}
