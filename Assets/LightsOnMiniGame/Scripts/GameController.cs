using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
                    hit.collider.gameObject.transform.GetComponent<LightsOnButton>().ChangeColor();
                    hit.collider.gameObject.transform.GetComponent<LightsOnButton>().ChangeAdjacent();
                    //Debug.Log("Button pressed");
                }
            }
        }
    }
}
