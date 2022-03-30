using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    private Line[] lines;
    private int currLine;

    private bool gameEnd;

    public string word;

    private void Awake()
    {
        lines = GetComponentsInChildren<Line>();
    }

    public bool isValidInput()
    {
        return lines[currLine].isValidInput();
    }

    public void CheckForCorrectAnswer()
    {
        if (gameEnd) return;

        Line line = lines[currLine];
        bool isValid = line.CheckForCorrectAnswer(word);

        if(isValid)
        {
            gameEnd = true;
            line.Win();
        }
        else if(++currLine == lines.Length)
        {
            gameEnd = true;
            //complete failure
            //reset
        }
    }

    public void EnterLetter(LetterController letterController)
    {
        if (gameEnd) return;

        lines[currLine].EnterLetter(letterController);
    }

    public void DeleteLastInput()
    {
        if (gameEnd) return;

        lines[currLine].DeleteLastInput();
    }
}
