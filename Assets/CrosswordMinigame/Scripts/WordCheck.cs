using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


namespace Crossword
{
    public class WordCheck : MonoBehaviour
    {
        [SerializeField] private GameObject[] word;
        [SerializeField] private TMP_InputField inputField;

        public bool wordComplete = false;

        public int placement = 0;
        private EventSystem currentSystem;

        private void Awake()
        {
            int length = word.Length;


            currentSystem = EventSystem.current;
            inputField.characterLimit = 1;
            inputField.onValueChanged.AddListener(WordLettersHandler);
        }

        private void Update()
        {
            if (currentSystem.currentSelectedGameObject != null)
            {
                inputField = currentSystem.currentSelectedGameObject.GetComponent<TMP_InputField>();

                int i = 0;
                foreach (GameObject letter in word)
                {                        
                    if (letter.GetComponent<TMP_InputField>() == inputField)
                    {
                        placement = i;
                        break;
                    }
                    i++;
                }
            }
        }

        private void WordLettersHandler(string arg0)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(arg0, @"^[a-zA-Z]+$"))
            {
                inputField = word[placement].GetComponent<TMP_InputField>();

                inputField.text = "";
                return;
            }

            placement++;

            while (true)
            {
                if (placement < word.Length)
                    inputField = word[placement].GetComponent<TMP_InputField>();

                // Set on first available input field, if it exists
                if (!inputField.enabled && placement < word.Length)
                    placement++;
                else
                    break;
            }

            if (placement < word.Length)
            {                 
                inputField.onValueChanged.AddListener(WordLettersHandler);
                currentSystem.SetSelectedGameObject(word[placement]);
                
            } else if (placement >= word.Length)
            {
                foreach (GameObject letter in word)
                {
                    LetterCheck letterCheck = letter.GetComponent<LetterCheck>();

                    

                    // If this returns false, do nothing
                    if (!letterCheck.TextCheckHandler(letter.GetComponent<TMP_InputField>().text))
                    {
                        currentSystem.SetSelectedGameObject(null);
                        return;
                    }
                        
                    
                    if (letter.GetComponent<LetterCheck>().isStartingLetter)
                    {
                        currentSystem.SetSelectedGameObject(null);
                        Debug.Log("Is Starting Letter");
                    }
                }

                // If all returned true, set the text
                foreach (GameObject letter in word)
                {
                    LetterCheck letterCheck = letter.GetComponent<LetterCheck>();
                    
                    letterCheck.SetText(letter.GetComponent<TMP_InputField>().text);

                    wordComplete = true;

                    //reset placement? in all word checks?
                    placement = 0;
                    currentSystem.SetSelectedGameObject(null);
                }

                //currentSystem.SetSelectedGameObject(null);
                return;
            }


        }
    }
}
