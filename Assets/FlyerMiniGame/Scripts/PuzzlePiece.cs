using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public Image childPuzzlePieceImage;
    public bool isActive = false;

    private Button myButton;

    public void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => SetPuzzlePieceActive());

        childPuzzlePieceImage = GetComponentsInChildren<Image>()[1];
        childPuzzlePieceImage.gameObject.SetActive(false);
        
        transform.parent.GetComponent<PuzzleManager>().puzzlePieces.Add(this);
    }
    public void SetPuzzlePieceActive()
    {
        print(this.name + " is active!");
        childPuzzlePieceImage.gameObject.SetActive(true);
        isActive = true;
        myButton.onClick.RemoveListener(() => SetPuzzlePieceActive());
        transform.parent.GetComponent<PuzzleManager>().CheckForCompletePuzzle();
    }

    //currently not used but could be useful maybe ?!
    public void SetPuzzlePieceInactive()
    {
        childPuzzlePieceImage.gameObject.SetActive(false);
        isActive = false;
    }
}
