using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {
    Text text;
    bool specialText = false;

    /** Represents text that should be modified in some way (e.g. <color=cyan>SomethingSomething</color>). */
    string modifier1; string textInbetween; string modifier2;

    void Awake() {
        text = GetComponentInChildren<Text>();
    }

    public void TypeText(string textToBeDisplayed, float textSpeed) {
        StartCoroutine(CoTypeText(textToBeDisplayed, textSpeed));
    }

    public IEnumerator CoTypeText(string textToBeDisplayed, float textSpeed) {
        // <GARBAGE1>TextToBeChanged<GARBAGE2>
        //<GARBAGE1>T<GARBAGE2><GARBAGE1>E<GARBAGE2> ... <GARBAGE1>D<GARBAGE2>
        for (int i = 0, j = 0; i < textToBeDisplayed.Length; i++) {
            if (textToBeDisplayed[i] == '<' || specialText) {
                specialText = true;
                if (modifier1 == null) {
                    modifier1 = util.ParseUntil(textToBeDisplayed.Substring(i), '>'); // <GARBAGE1>
                    textInbetween = textToBeDisplayed.Remove(i, i + modifier1.Length);
                   // Debug.Log("substring: " + textToBeDisplayed.Substring(i + modifier1.Length + textInbetween.Length));
                    modifier2 = util.ParseUntil(textToBeDisplayed.Substring(i + modifier1.Length + textInbetween.Length), '>');
                   // Debug.Log("Inbetween: " + textInbetween)
                   // Debug.Log("Mod1: " + modifier1);
                   // Debug.Log("Mod2: " + modifier2);
                }
                if (j == textInbetween.Length - 1) {
                    specialText = false;
                    j = 0;
                    modifier1 = null;
                }
                text.text += modifier1 + textInbetween[j] + modifier2;
                j++;
            } else {
                text.text += textToBeDisplayed[i];
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    public void ClearAllLetters() {
        //fucking hell.
    }
}
