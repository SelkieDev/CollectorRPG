﻿using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {
    Text text;

    /** Represents text that should be modified in some way (e.g. <color=cyan>SomethingSomething</color>). */
    string modifier1; string textInbetween; string modifier2;

    /** Use images[spriteIndex].sprite to set the sprite of the character box. */
    Image[] images; int spriteIndex;

    void Awake() {
        images = GetComponentsInChildren<Image>();
        text = GetComponentInChildren<Text>();
        Image[] sprites = GetComponentsInChildren<Image>();
        for (int i = 0; i < sprites.Length; i += 1) {
            if (sprites[i].sprite == null) {
                spriteIndex = i;
                break;
            }
        }
    }

    void OnDisable() {
        ClearAllLetters();
        images[spriteIndex].sprite = null;
    }

    /** Classes other than TextManager SHOULD NOT call this function.
      * Instead they should call TextManager.SpawnText______. */
    public void TypeText(string textToBeDisplayed, float textSpeed, Sprite sprite = null) {
        StopAllCoroutines();
        modifier1 = modifier2 = textInbetween = null;
        ClearAllLetters();
        if (sprite == null) {
            StartCoroutine(CoTypeText(textToBeDisplayed, textSpeed));
        } else {
            images[spriteIndex].sprite = sprite;
            StartCoroutine(CoTypeText(textToBeDisplayed, textSpeed));
        }
    }

    /** Displays TEXTTOBEDISPLAYED at one character per TEXTSPEED seconds. */
    IEnumerator CoTypeText(string textToBeDisplayed, float textSpeed) {
        bool specialText = false;
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
                    if (i >= textToBeDisplayed.Length) {
                        break;
                    }
                    text.text += textToBeDisplayed[i];
                } else {
                    text.text += modifier1 + textInbetween[j] + modifier2;
                    j++;
                }
            }
            else {
                text.text += textToBeDisplayed[i];
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /** Clears all letters from the textbox. */
    public void ClearAllLetters() {
        text.text = null;
    }

    /** Once a modifier is found, this function will parse it out and give you the text
      * inbetween. */
    void ParseOutModifiers(string textToBeDisplayed, int index) {
        modifier1 = util.ParseUntil(textToBeDisplayed.Substring(index), '>');
        textInbetween = String.Copy(textToBeDisplayed).Substring(index + modifier1.Length);
        modifier2 = util.ParseUntil(textInbetween, '>');
        textInbetween = util.ParseUntil(textInbetween, '<');
        textInbetween = textInbetween.Remove(textInbetween.Length - 1, 1);
        modifier2 = modifier2.Remove(0, textInbetween.Length);
    }


}
