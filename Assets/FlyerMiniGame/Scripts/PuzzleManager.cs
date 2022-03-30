using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<PuzzlePiece> puzzlePieces;
    public GameObject puzzleFaded;
    public GameObject completedPuzzle;

    public void CheckForCompletePuzzle()
    {
        foreach(PuzzlePiece p in puzzlePieces)
        {
            if(!p.isActive)
            {
                print("Not all pieces used!");
                return;
            }
        }

        FinishPuzzle();
    }

    public void FinishPuzzle()
    {
        puzzleFaded.SetActive(false);
        completedPuzzle.SetActive(true);
        foreach(PuzzlePiece p in puzzlePieces)
        {
            p.gameObject.SetActive(false);
        }

        print("Finished Puzzle! Success!");
    }
}
