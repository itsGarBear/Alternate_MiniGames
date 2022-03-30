using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Crossword
{

    public class LetterCheck : MonoBehaviour
    {
        [SerializeField] private DesiredLetter letter;
        //[SerializeField] private GameObject[] word;
        [SerializeField] private Image img;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI placeholderText;
        [SerializeField] public bool isStartingLetter;

        private void Awake()
        {
            inputField.characterLimit = 1;

            //int length = word.Length;

           placeholderText.text = "";
        }

        public bool TextCheckHandler(string arg0)
        {
            if(arg0 == letter.UpperCase || arg0 == letter.LowerCase)
            {
                return true;
            }
            //img.color = Color.red;
            return false;
        }

        public void SetText(string arg0) 
        {
            if (arg0 == letter.LowerCase)
            {
                inputField.text = letter.UpperCase;
                img.color = Color.green;
                inputField.enabled = false;
                return;
            }
        }


        //private void WordLettersHandler(string arg0)
        //{
        //    placement++;

        //    if (placement >= word.Length)
        //    {
        //        placement = 0;
        //    }

        //    currentSystem.SetSelectedGameObject(word[placement]);
        //}
    }
}
