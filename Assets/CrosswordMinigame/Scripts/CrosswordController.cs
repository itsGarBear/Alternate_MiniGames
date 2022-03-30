using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crossword
{
    public class CrosswordController : MonoBehaviour
    {
        public GameObject[] words;
        public GameObject winScreen;

        private void Start()
        {
            winScreen.SetActive(false);
            Debug.Log("Inactive");
        }

        private void Update()
        {
            CheckEndGame(); 
        }

        private void CheckEndGame()
        {
            foreach (GameObject word in words)
            {
                WordCheck wordCheck = word.GetComponent<WordCheck>();

                Debug.Log(wordCheck.wordComplete);

                if (!wordCheck.wordComplete)
                    return;
            }

            winScreen.SetActive(true);
        }
    }
}
