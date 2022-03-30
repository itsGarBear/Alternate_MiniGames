using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Randomizer : MonoBehaviour
{
    public bool isLevel1 = true;
    public TextMeshProUGUI text;

    private List<LightsOnButton> lightsOutButtons = new List<LightsOnButton>();

    [Header("Change Me")]
    public List<LightsOnButton> level1Solution;
    public List<LightsOnButton> level2Solution;

    [Header("Don't Change Me")]
    public List<LightsOnButton> correctInactiveButtons;

    //MAKE ME AN EVENT
    void Start()
    {
        foreach (LightsOnButton b in UnityEngine.Object.FindObjectsOfType(typeof(LightsOnButton)) as LightsOnButton[])
        {
            lightsOutButtons.Add(b);
        }

        Invoke("ResetGame", 1f);
    }

    public void FindInactiveButtons(bool isFirstLevel)
    {
        if(isFirstLevel)
        {
            foreach (LightsOnButton b in lightsOutButtons)
            {
                if (!level1Solution.Contains(b))
                {
                    correctInactiveButtons.Add(b);
                    print("added first level");
                }
            }
        }
        else
        {
            foreach (LightsOnButton b in lightsOutButtons)
            {
                if (!level2Solution.Contains(b))
                {
                    correctInactiveButtons.Add(b);
                    print("added second level");
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Button")
                {
                    if(checkWin() && isLevel1)
                    {
                        Debug.Log("Congratulations, you cleared the level 1!");
                        text.text = "Congratulations, you cleared the level 1!";
                        isLevel1 = false;
                        Invoke("ResetGame", 3f);
                    }
                    else if(checkWin() && !isLevel1)
                    {
                        Debug.Log("Congratulations, you cleared the level 2!");
                        text.text = "Congratulations, you cleared the level 2!";
                    }
                }
            }
        }
    }

    public void ResetGame()
    {
        foreach (LightsOnButton b in lightsOutButtons)
        {
            b.Reset();
        }

        correctInactiveButtons.Clear();
        FindInactiveButtons(isLevel1);

        text.text = "";
    }

    void checkForButtons(string[] buttonsToTurnOn)
    {
        foreach (LightsOnButton b in lightsOutButtons)
        {
            for (int i = 0; i < buttonsToTurnOn.Length; i++)
            {
                if (b.transform.name == buttonsToTurnOn[i])
                {
                    //Debug.Log(buttonsToTurnOn[i]);
                    b.Enable();
                }
            }
        }
    }

    bool checkWin()
    {
        if (checkCorrectActive() && checkCorrectInactive())
            return true;
        else
            return false;
    }

    bool checkCorrectActive()
    {
        if(isLevel1)
        {
            foreach (LightsOnButton b in level1Solution)
            {
                if (!b.isActive)
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            foreach (LightsOnButton b in level2Solution)
            {
                if (!b.isActive)
                {
                    return false;
                }
            }

            return true;
        }
        
    }

    bool checkCorrectInactive()
    {
        foreach (LightsOnButton b in correctInactiveButtons)
        {
            if (b.isActive)
            {
                return false;
            }
        }

        return true;
    }
}
