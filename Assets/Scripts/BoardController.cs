using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static BoardController Instance;

    [SerializeField] Tile tile;

    [SerializeField] Transform cam;

    [SerializeField] Piece piece;

    [SerializeField] public UnityEngine.Color availableMoveHighlight, lastMoveHighlight;

    const int boardWidth = 8;
    const int boardHeight = 8;
    Tile[,] board;

    public Piece selectedPiece;

    public List<Tile> availableMoves = new List<Tile>();

    private void Awake()
    {
        Instance = this;
    }

    public void CreateBoard()
    {
        board = new Tile[boardHeight, boardWidth];
        for (int y = 0; y < boardHeight; y++)
        {
            for (int x = 0; x < boardWidth; x++)
            {
                board[x, y] = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                board[x, y].name = $"{x} {y}";
                board[x, y].Initialize(((x + y) % 2 != 0));
            }
        }

        cam.transform.position = new Vector3((float)boardWidth / 2 - 0.5f, (float)boardWidth / 2 - 0.5f, -10);

        GameManager.Instance.UpdateState(State.SetPieces);
    }

    public async void SetPiecesFromFEN(string fen)
    {
        string[] parts = fen.Split();

        int x = 0, y = 7;

        foreach (var c in parts[0])
        {
            if(c >= 66 && c <= 82 || c >= 98 && c <= 114)
            {
                await Task.Delay(50);
                SpawnPiece(c, x, y);
                x++;
            }
                 
            if (int.TryParse(c.ToString(), out int num))
            {
                for (int i = 0; i < num; i++)
                {
                    x++;
                }
            }

            if (c == '/')
            {
                y--;
                x = 0;
            }
                
        }

        if (parts[1] == "w")
            GameManager.Instance.UpdateState(State.White);
        else
            GameManager.Instance.UpdateState(State.Black);

        FindObjectOfType<AudioManager>().Play("Start");
    }

    void SpawnPiece(char c, int x, int y)
    {
        var spawnedPiece = Instantiate(piece, new Vector3(x, y), Quaternion.identity);
        spawnedPiece.Initialize(c);
        spawnedPiece.name = spawnedPiece.GetComponent<SpriteRenderer>().sprite.name;
        board[x, y].SetPiece(spawnedPiece);
    }

    public void SetSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
    }

    public void ShowAvailableMoves()
    {
        if(availableMoves != null)
        {
            HideAvailableMoves();
            availableMoves.Clear();
        }
        
        if(selectedPiece != null)
        {
            switch (selectedPiece.type)
            {
                case PieceType.Rook:
                    availableMoves = MoveCalculator.CalculateRookMoves(board, selectedPiece);
                    break;
                case PieceType.Pawn:
                    availableMoves = MoveCalculator.CalculatePawnMoves(board, selectedPiece);
                    break;
                case PieceType.Bishop:
                    availableMoves = MoveCalculator.CalculateBishopMoves(board, selectedPiece);
                    break;
                case PieceType.Knight:
                    availableMoves = MoveCalculator.CalculateKnightMoves(board, selectedPiece);
                    break;
                case PieceType.Queen:
                    availableMoves = MoveCalculator.CalculateQueenMoves(board, selectedPiece);
                    break;
                case PieceType.King:
                    availableMoves = MoveCalculator.CalculateKingMoves(board, selectedPiece);
                    break;
            }

            MoveCalculator.FindAttackingTiles(board);
            foreach (var tile in availableMoves)
            {
                tile.EnableHighlight(availableMoveHighlight);
            }

        }
    }

    public void HideAvailableMoves()
    {
        foreach (var tile in availableMoves)
            tile.DisableHighlight();
    }


    public void DisableAllHighlights()
    {
        foreach (var tile in board)
            tile.DisableHighlight();
    }
}
