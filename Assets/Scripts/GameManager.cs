using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Board boardPrefab;
    public King redKingPrefab;
    public King blueKingPrefab;
    public Pawn bluePawnPrefab;
    public Pawn redPawnPrefab;
   
    private Board boardInstance;
    private King redKingInstance;
    private King blueKingInstance;
    private Pawn[] redPawns;
    private Pawn[] bluePawns;

    private void Start()
    {
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame() {
        boardInstance = Instantiate(boardPrefab) as Board;
        boardInstance.Generate();
        InizilizePieces();

    }

    private void InizilizePieces()
    {
        redPawns = new Pawn[4];
        bluePawns = new Pawn[4];
        for (int x = 0; x < 4; x++)
        {
            redPawns[x] = Instantiate(redPawnPrefab) as Pawn;
            bluePawns[x] = Instantiate(bluePawnPrefab) as Pawn;
            if (x < 2)
            {
                redPawns[x].Initilize(boardInstance.spaces[0, x]);
                bluePawns[x].Initilize(boardInstance.spaces[4, x]);
            }
            else
            {
                redPawns[x].Initilize(boardInstance.spaces[0, x+1]);
                bluePawns[x].Initilize(boardInstance.spaces[4, x+1]);
            }
            
        }
        redKingInstance = Instantiate(redKingPrefab) as King;
        redKingInstance.Initilize(boardInstance.spaces[0, 2]);
        blueKingInstance = Instantiate(blueKingPrefab) as King;
        blueKingInstance.Initilize(boardInstance.spaces[4, 2]);
    }

    private void RestartGame() {
        Destroy(boardInstance.gameObject);
        BeginGame();
    }
}
