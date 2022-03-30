using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 correctPos;
    private SpriteRenderer spriteRenderer;
    public int number;
    public bool inRightPlace = false;

    // Start is called before the first frame update
    void Awake()
    {
        targetPos = transform.position;
        correctPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
        if(targetPos == correctPos)
        {
            spriteRenderer.color = Color.white;
            inRightPlace = true;
        }
        else
        {
            spriteRenderer.color = new Color(.4f, .4f, .4f, 1);
            inRightPlace = false;
        }
    }
}
