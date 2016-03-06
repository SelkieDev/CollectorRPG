using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    string text;
    bool italicsOn = false;
    public GameObject letter;
    public RectTransform firstLine, secondLine, thirdLine, boxTransform;
    RectTransform letterOriginTransform;
    float kerningSize = Screen.width * .034f;
    int characters = 0;
    int lineMax = 36;
    string color = "black";

    public void TypeText(string textToBeDisplayed, float textSpeed) {
        StartCoroutine(CoTypeText(textToBeDisplayed, textSpeed));
    }

    public IEnumerator CoTypeText(string textToBeDisplayed, float textSpeed) {

        letterOriginTransform = firstLine;
        text = textToBeDisplayed;
        characters = 0;

        for (int i = 0; i < text.Length; i++)
        {
            // If a ^ is detected, the next number that is read in will decide what color to set the word to.
            if (text[i].ToString() == "^")
            {
                ColorSelector(text[i + 1].ToString());
                i += 2;
            }
            // A space will make the color default to white and turn of italics.
            else if (text[i].ToString() == " ")
            {
                color = "white";
                italicsOn = false;
            }

            // A ~ turns on italics
            if (text[i].ToString() == "~")
            {
                italicsOn = !italicsOn;
                i++;
            }

            if (text[i].ToString() != "^")
            {
                if (italicsOn == false)
                {
                    // This condition stops ~ modifier from being printed into dialog.
                    if (text[i].ToString() != "~")
                    {
                        GameObject textLetter = Instantiate(letter, new Vector2(letterOriginTransform.localPosition.x + (characters * kerningSize), letterOriginTransform.localPosition.y), letterOriginTransform.localRotation) as GameObject;
                        textLetter.GetComponent<RectTransform>().SetParent(boxTransform, false);
                        ColorSetter(textLetter, color);
                        textLetter.GetComponent<Text>().text = text[i].ToString();
                    }
                }
                else if (italicsOn == true && text[i].ToString() != "~")
                {
                    GameObject textLetter = Instantiate(letter, new Vector2(letterOriginTransform.localPosition.x + (characters * kerningSize), letterOriginTransform.localPosition.y), letterOriginTransform.localRotation) as GameObject;
                    textLetter.GetComponent<RectTransform>().SetParent(boxTransform, false);
                    ColorSetter(textLetter, color);
                    textLetter.GetComponent<Text>().text = text[i].ToString();
                    textLetter.GetComponent<Text>().fontStyle = FontStyle.Italic;

                }
            }

            yield return new WaitForSeconds(textSpeed);

            characters += 1;
            if (letterOriginTransform == firstLine && characters > lineMax)
            {
                characters = 0;
                letterOriginTransform = secondLine;
            } else if ( letterOriginTransform == secondLine && characters > lineMax)
            {
                characters = 0;
                letterOriginTransform = thirdLine;
            }
        }
    }

    void ColorSelector(string index)
    {
        switch (index)
        {
            case "0":
                color = "black";
                break;
            case "1":
                color = "red";
                break;
            case "2":
                color = "magenta";
                break;
            case "3":
                color = "yellow";
                break;
            case "4":
                color = "green";
                break;
            case "5":
                color = "cyan";
                break;
            case "6":
                color = "blue";
                break;
        }
    }

    void ColorSetter(GameObject text, string color)
    {
        switch (color)
        {
            case "black":
                text.GetComponent<Text>().color = Color.black;
                break;
            case "red":
                text.GetComponent<Text>().color = Color.red;
                break;
            case "magenta":
                text.GetComponent<Text>().color = Color.magenta;
                break;
            case "yellow":
                text.GetComponent<Text>().color = Color.yellow;
                break;
            case "green":
                text.GetComponent<Text>().color = Color.green;
                break;
            case "cyan":
                text.GetComponent<Text>().color = Color.cyan;
                break;
            case "blue":
                text.GetComponent<Text>().color = Color.blue;
                break;

        }
    }

    public void ClearAllLetters()
    {
        GameObject[] letters = GameObject.FindGameObjectsWithTag("Letter");

        foreach (GameObject letter in letters)
        {
            Destroy(letter);
        }
    }
}
