using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] Sprite whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whitePawn, blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackPawn;

    [SerializeField] SpriteRenderer spriteRenderer;

    public PieceColor color;
    public PieceType type;

    public Tile tile;

    public int xValue, yValue;

    private void Update()
    {
        xValue = (int)transform.position.x;
        yValue = (int)transform.position.y;
    }
    public void Initialize(char piece)
    {
        switch (piece)
        {
            case 'r':
                spriteRenderer.sprite = blackRook;
                color = PieceColor.Black;
                type = PieceType.Rook;
                break;
            case 'n':
                spriteRenderer.sprite = blackKnight;
                color = PieceColor.Black;
                type = PieceType.Knight;
                break;
            case 'b':
                spriteRenderer.sprite = blackBishop;
                color = PieceColor.Black;
                type = PieceType.Bishop;
                break;
            case 'q':
                spriteRenderer.sprite = blackQueen;
                color = PieceColor.Black;
                type = PieceType.Queen;
                break;
            case 'k':
                spriteRenderer.sprite = blackKing;
                color = PieceColor.Black;
                type = PieceType.King;
                break;
            case 'p':
                spriteRenderer.sprite = blackPawn;
                color = PieceColor.Black;
                type = PieceType.Pawn;
                break;
            case 'R':
                spriteRenderer.sprite = whiteRook;
                color = PieceColor.White;
                type = PieceType.Rook;
                break;
            case 'N':
                spriteRenderer.sprite = whiteKnight;
                color = PieceColor.White;
                type = PieceType.Knight;
                break;
            case 'B':
                spriteRenderer.sprite = whiteBishop;
                color = PieceColor.White;
                type = PieceType.Bishop;
                break;
            case 'Q':
                spriteRenderer.sprite = whiteQueen;
                color = PieceColor.White;
                type = PieceType.Queen;
                break;
            case 'K':
                spriteRenderer.sprite = whiteKing;
                color = PieceColor.White;
                type = PieceType.King;
                break;
            case 'P':
                spriteRenderer.sprite = whitePawn;
                color = PieceColor.White;
                type = PieceType.Pawn;
                break;
        }
    }

    
}

public enum PieceType
{
    Rook,
    Knight,
    Bishop,
    Queen,
    Pawn,
    King
}

public enum PieceColor
{
    Black,
    White
}
