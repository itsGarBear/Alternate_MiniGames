using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOnButton : MonoBehaviour
{
    public bool isActive;
    private Material activeMaterial;
    private Material inactiveMaterial;

    public LightsOnButton[] adjacentButtons;

    //MAKE ME AN EVENT
    void Start()
    {
        activeMaterial = Resources.Load<Material>("Materials/Active_MAT");
        inactiveMaterial = Resources.Load<Material>("Materials/Passive_MAT");

        if (isActive)
        {
            GetComponent<MeshRenderer>().material = inactiveMaterial;
            isActive = false;
        }
        else
        {
            GetComponent<MeshRenderer>().material = activeMaterial;
            isActive = true;
        }
    }

    public void ChangeColor()
    {
        if (isActive)
        {
            GetComponent<MeshRenderer>().material = inactiveMaterial;
            isActive = false;
        }
        else
        {
            GetComponent<MeshRenderer>().material = activeMaterial;
            isActive = true;
        }
    }

    public void ChangeAdjacent()
    {
        foreach (LightsOnButton b in adjacentButtons)
        {
            if (b.isActive)
            {
                b.GetComponent<MeshRenderer>().material = inactiveMaterial;
                b.isActive = false;
            }
            else if (!b.isActive)
            {
                b.GetComponent<MeshRenderer>().material = activeMaterial;
                b.isActive = true;
            }
        }
    }

    public void Reset()
    {
        isActive = false;
        GetComponent<MeshRenderer>().material = inactiveMaterial;
    }

    public void Enable()
    {
        isActive = true;
        GetComponent<MeshRenderer>().material = activeMaterial;
    }
}
