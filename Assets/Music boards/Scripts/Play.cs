using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Play : MonoBehaviour
{

    public static bool isLoop;

    private Renderer render;
    private Color originalColor;
    public bool activated;

    [SerializeField]
    private float secondsBetweenRows = 0.15f;

    private void Start()
    {
        render = GetComponentInChildren<Renderer>();
        originalColor = render.material.color;
        activated = false;
        isLoop = false;
    }

  

    public void PlayAllRows()
    {
        activated = !activated;
        if (activated)
        {
            isLoop = true;

            if(GetPianoBoard() != null)
                StartCoroutine(PlayPianoSoundsCoroutine());
            if (GetGuitarBoard() != null)
                StartCoroutine(PlayGuitarSoundsCoroutine());
            if (GetDirtBoard() != null)
                StartCoroutine(PlayDirtSoundsCoroutine());
            if (GetBassBoard() != null)
                StartCoroutine(PlayBassSoundsCoroutine());
            if (GetSprayBoard() != null)
                StartCoroutine(PlaySpraySoundsCoroutine());
            if (GetClimbBoard() != null)
                StartCoroutine(PlayClimbSoundsCoroutine());

            render.material.SetColor("_BaseColor", Color.red);
        }
        else
        {
            isLoop = false;
            StopAllCoroutines();
            render.material.SetColor("_BaseColor", originalColor);
        }
    }

    #region PlayBoards
    IEnumerator PlayPianoSoundsCoroutine()
    {
        while (isLoop)
        {
            var k = GetPianoBoard();

            foreach (Transform row in k.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }

    IEnumerator PlayGuitarSoundsCoroutine()
    {
        while (isLoop)
        {
            var g = GetGuitarBoard();

            foreach (Transform row in g.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }

    IEnumerator PlayDirtSoundsCoroutine()
    {
        while (isLoop)
        {
            var g = GetDirtBoard();

            foreach (Transform row in g.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }

    IEnumerator PlayBassSoundsCoroutine()
    {
        while (isLoop)
        {
            var g = GetBassBoard();

            foreach (Transform row in g.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }

    IEnumerator PlaySpraySoundsCoroutine()
    {
        while (isLoop)
        {
            var k = GetSprayBoard();

            foreach (Transform row in k.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }

    IEnumerator PlayClimbSoundsCoroutine()
    {
        while (isLoop)
        {
            var k = GetClimbBoard();

            foreach (Transform row in k.transform)
            {
                row.GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(secondsBetweenRows);
            }
        }
    }
    #endregion


    #region GetBoards
    private GameObject GetGuitarBoard()
    {
        return BoardManager.boards.Find(b => b.name == "GuitarBoard(Clone)");
    }

    private GameObject GetPianoBoard()
    {
        return BoardManager.boards.Find(b => b.name == "PianoBoard(Clone)");
    }

    private GameObject GetDirtBoard()
    {
        return BoardManager.boards.Find(b => b.name == "DirtBoard(Clone)");
    }

    private GameObject GetBassBoard()
    {
        return BoardManager.boards.Find(b => b.name == "BassBoard(Clone)");
    }

    private GameObject GetSprayBoard()
    {
        return BoardManager.boards.Find(b => b.name == "SprayBoard(Clone)");
    }
    private GameObject GetClimbBoard()
    {
        return BoardManager.boards.Find(b => b.name == "ClimbBoard(Clone)");
    }
    #endregion

}


