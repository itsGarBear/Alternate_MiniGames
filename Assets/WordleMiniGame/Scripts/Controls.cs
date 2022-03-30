using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int MAX_VALUE;

    public GameField gameField;
    private int valuesEntered;

    public void CheckForCorrectAnswer()
    {
        if (!gameField.isValidInput()) return;

        gameField.CheckForCorrectAnswer();
        valuesEntered = 0;
    }

    public void DeleteLastInput()
    {
        if (valuesEntered == 0) return;

        gameField.DeleteLastInput();

        valuesEntered--;
    }

    public void EnterLetter(LetterController letterController)
    {
        if (valuesEntered >= MAX_VALUE) return;

        gameField.EnterLetter(letterController);

        valuesEntered++;
    }
}
