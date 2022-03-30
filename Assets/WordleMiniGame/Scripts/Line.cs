using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Line : MonoBehaviour
{
    private Image[] images;
    public Text[] texts;
    private int currField;
    private LetterController[] letterControllers;

    private void Awake()
    {
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<Text>();

        letterControllers = new LetterController[images.Length];
    }

    public bool isValidInput()
    {
        //check if word is in list?
        return true;
    }

    public bool CheckForCorrectAnswer(string word)
    {
        currField = 0;
        var text = texts.Aggregate("", (current, textMesh) => current + textMesh.text).ToLowerInvariant();

        var colors = new Color[texts.Length];
        var seenIndexes = new List<int>();
        var correctAnswers = new Dictionary<char, int>();

        for (var i = 0; i < texts.Length; i++)
        {
            var inputChar = '\0';
            try
            {
                inputChar = texts[i].text[0];
            }
            catch
            {
                print("could not find char");
            }
            
            if (inputChar.Equals(word[i]))
            {
                colors[i] = ColorCollection.Green;

                if (correctAnswers.ContainsKey(inputChar))
                {
                    correctAnswers[inputChar]++;
                }
                else
                {
                    correctAnswers[inputChar] = 1;
                }

                seenIndexes.Add(i);
            }
            else if (!word.Contains(inputChar))
            {
                colors[i] = ColorCollection.Grey;
                seenIndexes.Add(i);
            }
        }

        for (var i = 0; i < texts.Length; i++)
        {
            if (seenIndexes.Contains(i)) continue;

            var inputChar = texts[i].text[0];

            colors[i] = ColorCollection.Yellow;

            var answerCountTotal = word.Count(c => c.Equals(inputChar));

            if (correctAnswers.ContainsKey(inputChar) && correctAnswers[inputChar] == answerCountTotal)
            {
                colors[i] = ColorCollection.Grey;
                continue;
            }

            var inputCountCurrent = 0;

            for (var j = 0; j < i; j++)
            {
                var charInner = texts[j].text[0];
                if (charInner.Equals(inputChar) && ++inputCountCurrent >= answerCountTotal)
                {
                    colors[i] = ColorCollection.Grey;
                    break;
                }
            }
        }

        for (var i = 0; i < images.Length; i++)
        {
            letterControllers[i].ChangeColorControl(colors[i]);

        }

        return text.Equals(word);
    }

    public void Win()
    {
        print("Winner");
    }

    public void EnterLetter(LetterController letterController)
    {
        letterControllers[currField] = letterController;
        texts[currField++].text = letterController.GetLetter();
    }

    public void DeleteLastInput()
    {
        texts[--currField].text = "";
    }
}
