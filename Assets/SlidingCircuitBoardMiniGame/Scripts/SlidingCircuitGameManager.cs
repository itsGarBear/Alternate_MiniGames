using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingCircuitGameManager : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceNdx = 15;
    public bool isSolved = false;

    public float hitRadius;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit)
            {
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < hitRadius)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript currTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = currTile.targetPos;
                    currTile.targetPos = lastEmptySpacePosition;

                    int tileNdx = findNdx(currTile);
                    tiles[emptySpaceNdx] = tiles[tileNdx];
                    tiles[tileNdx] = null;
                    emptySpaceNdx = tileNdx;
                }
            }
        }

        if(!isSolved)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                    {
                        correctTiles++;
                    }
                }
            }
            if (correctTiles == tiles.Length - 1)
            {
                print("You solved it! Woohoo!");
                isSolved = true;
            }
        }
        
    }

    public void Shuffle()
    {
        if(emptySpaceNdx != 15)
        {
            var tile15LastPos = tiles[15].targetPos;
            tiles[15].targetPos = emptySpace.position;
            emptySpace.position = tile15LastPos;

            tiles[emptySpaceNdx] = tiles[15];
            tiles[15] = null;
            emptySpaceNdx = 15;
        }

        int inversion;
        do
        {
            for (int i = 0; i <= 14; i++)
            {
                var lastPos = tiles[i].targetPos;
                int randomNdx = Random.Range(0, 14);

                tiles[i].targetPos = tiles[randomNdx].targetPos;
                tiles[randomNdx].targetPos = lastPos;

                var tile = tiles[i];
                tiles[i] = tiles[randomNdx];
                tiles[randomNdx] = tile;
            }

            inversion = GetInversionsOfPuzzle();
            print("Puzzle Shuffled");
        } while (inversion % 2 != 0);
    }

    public int findNdx(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if(tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public int GetInversionsOfPuzzle()
    {
        int inversionSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int currTileInversion = 0;
            for(int a = i; a < tiles.Length; a++)
            {
                if(tiles[a] != null)
                {
                    if(tiles[i].number > tiles[a].number)
                    {
                        currTileInversion++;
                    }
                }
            }
            inversionSum += currTileInversion;
        }

        return inversionSum;
    }
}
