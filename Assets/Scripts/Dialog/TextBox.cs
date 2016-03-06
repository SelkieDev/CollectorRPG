using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {
    Text text;

    void Awake() {
        text = GetComponentInChildren<Text>();
    }

    public void TypeText(string textToBeDisplayed, float textSpeed) {
        StartCoroutine(CoTypeText(textToBeDisplayed, textSpeed));
    }

    public IEnumerator CoTypeText(string textToBeDisplayed, float textSpeed) {
        
        for (int i = 0; i < textToBeDisplayed.Length; i++) {
            text.text += textToBeDisplayed[i];
            yield return new WaitForSeconds(textSpeed);  
        }
    }

    public void ClearAllLetters() {
        //fucking hell.
    }
}
