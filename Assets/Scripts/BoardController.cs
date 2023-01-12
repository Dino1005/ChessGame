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

    public List<Tile> availableMoves = null;

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
        HideAvailableMoves();
        availableMoves.Clear();
        if(selectedPiece != null)
        {
            switch (selectedPiece.type)
            {
                case PieceType.Rook:
                    CalculateRookMoves();
                    break;
                case PieceType.Pawn:
                    CalculatePawnMoves();
                    break;
                case PieceType.Bishop:
                    CalculateBishopMoves();
                    break;
                case PieceType.Knight:
                    CalculateKnightMoves();
                    break;
                case PieceType.Queen:
                    CalculateQueenMoves();
                    break;
                case PieceType.King:
                    CalculateKingMoves();
                    break;
            }

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

    private void CalculateKingMoves()
    {
        
    }

    private void CalculateQueenMoves()
    {
        CalculateBishopMoves();
        CalculateRookMoves();
    }

    private void CalculateKnightMoves()
    {
        if(selectedPiece.xValue + 2 < 8 && selectedPiece.yValue + 1 < 8)
        {
            if (board[selectedPiece.xValue + 2, selectedPiece.yValue + 1].piece != null)
            {
                if (board[selectedPiece.xValue + 2, selectedPiece.yValue + 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 2, selectedPiece.yValue + 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 2, selectedPiece.yValue + 1]);
        }

        if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue + 2 < 8)
        {
            if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 2].piece != null)
            {
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 2].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 2]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 2]);
        }

        if (selectedPiece.xValue - 2 >= 0 && selectedPiece.yValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue - 2, selectedPiece.yValue - 1].piece != null)
            {
                if (board[selectedPiece.xValue - 2, selectedPiece.yValue - 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 2, selectedPiece.yValue - 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 2, selectedPiece.yValue - 1]);
        }

        if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue - 2 >= 0)
        {
            if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 2].piece != null)
            {
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 2].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 2]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 2]);
        }

        if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue + 2 < 8)
        {
            if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 2].piece != null)
            {
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 2].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 2]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 2]);
        }

        if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue - 2 >= 0)
        {
            if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 2].piece != null)
            {
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 2].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 2]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 2]);
        }

        if (selectedPiece.xValue - 2 >= 0 && selectedPiece.yValue + 1 < 8)
        {
            if (board[selectedPiece.xValue - 2, selectedPiece.yValue + 1].piece != null)
            {
                if (board[selectedPiece.xValue - 2, selectedPiece.yValue + 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 2, selectedPiece.yValue + 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 2, selectedPiece.yValue + 1]);
        }

        if (selectedPiece.xValue + 2 < 8 && selectedPiece.yValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue + 2, selectedPiece.yValue - 1].piece != null)
            {
                if (board[selectedPiece.xValue + 2, selectedPiece.yValue - 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 2, selectedPiece.yValue - 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 2, selectedPiece.yValue - 1]);
        }
    }

    private void CalculateBishopMoves()
    {
        
    }

    private void CalculatePawnMoves()
    {
        if(selectedPiece.color == PieceColor.White)
        {
            if (selectedPiece.yValue == 1)
                if ((board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null) && (board[selectedPiece.xValue, selectedPiece.yValue + 2].piece == null))
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 2]);

            if(selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 1]);

            if (selectedPiece.yValue + 1 < 8 && selectedPiece.xValue - 1 >= 0)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece != null)
                    if(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);

            if (selectedPiece.yValue + 1 < 8 && selectedPiece.xValue + 1 < 8)
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece != null)
                    if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
                        availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 1]);

        }
        else
        {
            if (selectedPiece.yValue == 6)
                if ((board[selectedPiece.xValue, selectedPiece.yValue - 1].piece == null) && (board[selectedPiece.xValue, selectedPiece.yValue - 2].piece == null))
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue - 2]);

            if (selectedPiece.yValue - 1 >= 0)
                if (board[selectedPiece.xValue, selectedPiece.yValue - 1].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue - 1]);

            if (selectedPiece.yValue - 1 >= 0 && selectedPiece.xValue - 1 >= 0)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece != null)
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);

            if (selectedPiece.yValue - 1 >= 0 && selectedPiece.xValue + 1 < 8)
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece != null)
                    if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
        }
    }

    private void CalculateRookMoves()
    {
        for (int r = selectedPiece.xValue + 1; r < 8; r++)
        {
            if (board[r, selectedPiece.yValue].piece == null)
                availableMoves.Add(board[r, selectedPiece.yValue]);
            else
            {
                if(board[r, selectedPiece.yValue].piece.color != selectedPiece.color)
                    availableMoves.Add(board[r, selectedPiece.yValue]);
                break;
            }
        }

        for (int l = selectedPiece.xValue - 1; l >= 0; l--)
        {
            if (board[l, selectedPiece.yValue].piece == null)
                availableMoves.Add(board[l, selectedPiece.yValue]);
            else
            {
                if (board[l, selectedPiece.yValue].piece.color != selectedPiece.color)
                    availableMoves.Add(board[l, selectedPiece.yValue]);
                break;
            }
        }

        for (int u = selectedPiece.yValue + 1; u < 8; u++)
        {
            if (board[selectedPiece.xValue, u].piece == null)
                availableMoves.Add(board[selectedPiece.xValue, u]);
            else
            {
                if (board[selectedPiece.xValue, u].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue, u]);
                break;
            }
        }

        for (int d = selectedPiece.yValue - 1; d >= 0; d--)
        {
            if (board[selectedPiece.xValue, d].piece == null)
                availableMoves.Add(board[selectedPiece.xValue, d]);
            else
            {
                if (board[selectedPiece.xValue, d].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue, d]);
                break;
            }
        }
    }

    public void DisableAllHighlights()
    {
        foreach (var tile in board)
            tile.DisableHighlight();
    }
}
