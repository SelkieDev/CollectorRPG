using System.Collections;
using System;
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
        for (int i = 0, j = 0; i < textToBeDisplayed.Length; i++) {
            if (textToBeDisplayed[i] == '<' || specialText) {
                specialText = true;
                if (modifier1 == null) {
                    ParseOutModifiers(textToBeDisplayed, i);
                }
                if (j == textInbetween.Length) {
                    specialText = false;
                    j = 0;
                    i += modifier2.Length + modifier1.Length;
                    modifier1 = modifier2 = null;
                    text.text += textToBeDisplayed[i];
                    yield return new WaitForSeconds(textSpeed);
                } else {
                    text.text += modifier1 + textInbetween[j] + modifier2;
                    j++;
                }
                yield return new WaitForSeconds(textSpeed);
            }
            else {
                text.text += textToBeDisplayed[i];
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    public void ClearAllLetters() {
        //fucking hell.
    }

    void ParseOutModifiers(string textToBeDisplayed, int index) {
        modifier1 = util.ParseUntil(textToBeDisplayed.Substring(index), '>');
        textInbetween = String.Copy(textToBeDisplayed).Substring(index + modifier1.Length);
        modifier2 = util.ParseUntil(textInbetween, '>');
        textInbetween = util.ParseUntil(textInbetween, '<');
        textInbetween = textInbetween.Remove(textInbetween.Length - 1, 1);
        modifier2 = modifier2.Remove(0, textInbetween.Length);
    }
}
