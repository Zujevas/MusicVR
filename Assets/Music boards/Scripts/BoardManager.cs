using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bassBoardPrefab;
    [SerializeField]
    private GameObject guitarBoardPrefab;
    [SerializeField]
    private GameObject dirtBoardPrefab;
    [SerializeField]
    private GameObject pianoBoardPrefab;
    [SerializeField]
    private GameObject sprayBoardPrefab;
    [SerializeField]
    private GameObject climbBoardPrefab;

    GameObject guitarBoard;
    GameObject bassBoard;
    GameObject dirtBoard;
    GameObject pianoBoard;
    GameObject sprayBoard;
    GameObject climbBoard;

    public bool activated;
    public bool isLoop;

    public static List<GameObject> boards;
    private GameObject activeBoard;


    public GameObject pianoBoardTablet;
    public GameObject guitarBoardTablet;
    public GameObject dirtBoardTablet;
    public GameObject bassBoardTablet;
    public GameObject sprayBoardTablet;
    public GameObject climbBoardTablet;

    private void Start()
    {
        boards = new List<GameObject>();
        activated = false;
        isLoop = false;
    }

    public void SpawnBoard(string boardName)
    {
        switch (boardName)
        {
            case "guitar":
                UseGuitar();
                break;
            case "bass":
                UseBass();
                break;
            case "dirt":
                UseDirt();
                break;
            case "piano":
                UsePiano();
                break;
            case "spray":
                UseSpray();
                break;
            case "climb":
                UseClimb();
                break;
        }
    }

    private void UseGuitar()
    {
        // Instantiate guitar board if it does not exists
        if (guitarBoard == null)
        {
            guitarBoard = InstantiateBoard(guitarBoardPrefab, new Vector3(0, 0, 0));

            // Disable tablets and enable just guitar
            DisableAllTablets();
            guitarBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(guitarBoard);

            // Disable tablets and enable just guitar
            DisableAllTablets();
            guitarBoardTablet.SetActive(true);
        }
    }

    private void UseBass()
    {
        // Instantiate bass board if it does not exists
        if (bassBoard == null)
        {
            bassBoard = InstantiateBoard(bassBoardPrefab, new Vector3(-1, 0, 1));

            // Disable tablets and enable just bass
            DisableAllTablets();
            bassBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(bassBoard);

            DisableAllTablets();
            bassBoardTablet.SetActive(true);
        }
    }

    private void UseDirt()
    {
        // Instantiate dirt board if it does not exists
        if (dirtBoard == null)
        {
            dirtBoard = InstantiateBoard(dirtBoardPrefab, new Vector3(0, 0, 0));

            // Disable tablets and enable just dirt
            DisableAllTablets();
            dirtBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(dirtBoard);

            // Disable tablets and enable just dirt
            DisableAllTablets();
            dirtBoardTablet.SetActive(true);
        }
    }

    private void UsePiano()
    {
        // Instantiate piano board if it does not exists
        if (pianoBoard == null)
        {
            pianoBoard = InstantiateBoard(pianoBoardPrefab,new Vector3(0,0,0));

            // Disable tablets and enable just piano
            DisableAllTablets();
            pianoBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(pianoBoard);

            DisableAllTablets();
            pianoBoardTablet.SetActive(true);
        }
    }

    private void UseSpray()
    {
        // Instantiate piano board if it does not exists
        if (sprayBoard == null)
        {
            sprayBoard = InstantiateBoard(sprayBoardPrefab, new Vector3(0, 0, 0));

            // Disable tablets and enable just spray
            DisableAllTablets();
            sprayBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(sprayBoard);

            DisableAllTablets();
            sprayBoardTablet.SetActive(true);
        }
    }

    private void UseClimb()
    {
        // Instantiate piano board if it does not exists
        if (climbBoard == null)
        {
            climbBoard = InstantiateBoard(climbBoardPrefab, new Vector3(0, 0, 0));

            // Disable tablets and enable just climb
            DisableAllTablets();
            climbBoardTablet.SetActive(true);
        }
        else
        {
            HideAllBoards();
            EnableBoard(climbBoard);

            // Disable tablets and enable just climb
            DisableAllTablets();
            climbBoardTablet.SetActive(true);
        }
    }

    private void HideAllBoards()
    {
        Debug.Log("hide");
        foreach (var board in boards)
        {
            
            foreach (Transform row in board.transform)
            {
                foreach (Transform cube in row.transform)
                {
                    cube.gameObject.GetComponent<Renderer>().enabled = false;
                    cube.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
        }
    }

    private void EnableBoard(GameObject board)
    {

        foreach (Transform row in board.transform)
        {
            foreach (Transform cube in row.transform)
            {
                cube.gameObject.GetComponent<Renderer>().enabled = true;
                cube.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
        
    }

    private GameObject InstantiateBoard(GameObject boardPrefab, Vector3 offset)
    {
        HideAllBoards();
        GameObject board = Instantiate(boardPrefab, transform);
        board.transform.localPosition = new Vector3(0, 0, 0) + offset;
        board.transform.rotation = transform.rotation;
        boards.Add(board);
        activeBoard = board;

        return board;
    }

    void DisableAllTablets()
    {
        dirtBoardTablet.SetActive(false);
        pianoBoardTablet.SetActive(false);
        guitarBoardTablet.SetActive(false);
        bassBoardTablet.SetActive(false);
        sprayBoardTablet.SetActive(false);
        climbBoardTablet.SetActive(false);
    }

}