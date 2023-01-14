using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MoveCalculator
{
    public static List<Tile> attackTiles = new List<Tile>();
    public static List<Tile> CalculateKingMoves(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue + 1 < 8)
        {
            if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece != null)
            {
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 1]);
        }

        if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece != null)
            {
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
        }

        if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue + 1 < 8)
        {
            if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece != null)
            {
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);
        }

        if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece != null)
            {
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);
        }

        if (selectedPiece.xValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue - 1, selectedPiece.yValue].piece != null)
            {
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue]);
        }

        if (selectedPiece.xValue + 1 < 8)
        {
            if (board[selectedPiece.xValue + 1, selectedPiece.yValue].piece != null)
            {
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue]);
        }

        if (selectedPiece.yValue - 1 >= 0)
        {
            if (board[selectedPiece.xValue, selectedPiece.yValue - 1].piece != null)
            {
                if (board[selectedPiece.xValue, selectedPiece.yValue - 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue - 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue - 1]);
        }

        if (selectedPiece.yValue + 1 < 8)
        {
            if (board[selectedPiece.xValue, selectedPiece.yValue + 1].piece != null)
            {
                if (board[selectedPiece.xValue, selectedPiece.yValue + 1].piece.color != selectedPiece.color)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 1]);
            }
            else
                availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 1]);
        }

        return availableMoves;
    }

    public static List<Tile> CalculateQueenMoves(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        availableMoves.AddRange(CalculateBishopMoves(board, selectedPiece));
        availableMoves.AddRange(CalculateRookMoves(board, selectedPiece));

        return availableMoves;
    }

    public static List<Tile> CalculateKnightMoves(Tile[,] board, Piece selectedPiece)
    {
        List <Tile> availableMoves = new List<Tile>();

        if (selectedPiece.xValue + 2 < 8 && selectedPiece.yValue + 1 < 8)
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

        return availableMoves;
    }

    public static List<Tile> CalculateBishopMoves(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        for (int ru = 1; ru < 8; ru++)
        {
            if (selectedPiece.xValue + ru < 8 && selectedPiece.yValue + ru < 8)
            {
                if (board[selectedPiece.xValue + ru, selectedPiece.yValue + ru].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue + ru, selectedPiece.yValue + ru]);
                else
                {
                    if (board[selectedPiece.xValue + ru, selectedPiece.yValue + ru].piece.color != selectedPiece.color)
                        availableMoves.Add(board[selectedPiece.xValue + ru, selectedPiece.yValue + ru]);
                    break;
                }
            }
        }

        for (int rd = 1; rd < 8; rd++)
        {
            if (selectedPiece.xValue + rd < 8 && selectedPiece.yValue - rd >= 0)
            {
                if (board[selectedPiece.xValue + rd, selectedPiece.yValue - rd].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue + rd, selectedPiece.yValue - rd]);
                else
                {
                    if (board[selectedPiece.xValue + rd, selectedPiece.yValue - rd].piece.color != selectedPiece.color)
                        availableMoves.Add(board[selectedPiece.xValue + rd, selectedPiece.yValue - rd]);
                    break;
                }
            }
        }

        for (int lu = 1; lu < 8; lu++)
        {
            if (selectedPiece.xValue - lu >= 0 && selectedPiece.yValue + lu < 8)
            {
                if (board[selectedPiece.xValue - lu, selectedPiece.yValue + lu].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue - lu, selectedPiece.yValue + lu]);
                else
                {
                    if (board[selectedPiece.xValue - lu, selectedPiece.yValue + lu].piece.color != selectedPiece.color)
                        availableMoves.Add(board[selectedPiece.xValue - lu, selectedPiece.yValue + lu]);
                    break;
                }
            }
        }

        for (int ld = 1; ld < 8; ld++)
        {
            if (selectedPiece.xValue - ld >= 0 && selectedPiece.yValue - ld >= 0)
            {
                if (board[selectedPiece.xValue - ld, selectedPiece.yValue - ld].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue - ld, selectedPiece.yValue - ld]);
                else
                {
                    if (board[selectedPiece.xValue - ld, selectedPiece.yValue - ld].piece.color != selectedPiece.color)
                        availableMoves.Add(board[selectedPiece.xValue - ld, selectedPiece.yValue - ld]);
                    break;
                }
            }
        }

        return availableMoves;
    }

    public static List<Tile> CalculatePawnAttacks(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        if (selectedPiece.color == PieceColor.White)
        {
            if (selectedPiece.xValue - 1 >= 0 & selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece != null)
                {
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);
                }
                else
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);

            if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece != null)
                {
                    if (board[selectedPiece.xValue + 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
                        availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 1]);
                }
                else
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue + 1]);
        }
        else
        {
            if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue - 1 >= 0)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece != null)
                {
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);
                }
                else
                    availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);

            if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue - 1 >= 0)
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece != null)
                {
                    if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
                }
                else
                    availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
        }

        return availableMoves;
    }

    public static List<Tile> CalculatePawnMoves(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        if (selectedPiece.color == PieceColor.White)
        {
            if (selectedPiece.yValue == 1)
                if ((board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null) && (board[selectedPiece.xValue, selectedPiece.yValue + 2].piece == null))
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 2]);

            if (selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 1]);

            if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece != null)
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue + 1]);

            if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue + 1 < 8)
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

            if (selectedPiece.xValue - 1 >= 0 && selectedPiece.yValue - 1 >= 0)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece != null)
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue - 1, selectedPiece.yValue - 1]);

            if (selectedPiece.xValue + 1 < 8 && selectedPiece.yValue - 1 >= 0)
                if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece != null)
                    if (board[selectedPiece.xValue + 1, selectedPiece.yValue - 1].piece.color == PieceColor.White)
                        availableMoves.Add(board[selectedPiece.xValue + 1, selectedPiece.yValue - 1]);
        }

        return availableMoves;
    }

    public static List<Tile> CalculateRookMoves(Tile[,] board, Piece selectedPiece)
    {
        List<Tile> availableMoves = new List<Tile>();

        for (int r = selectedPiece.xValue + 1; r < 8; r++)
        {
            if (board[r, selectedPiece.yValue].piece == null)
                availableMoves.Add(board[r, selectedPiece.yValue]);
            else
            {
                if (board[r, selectedPiece.yValue].piece.color != selectedPiece.color)
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

        return availableMoves;
    }

    public static void FindAttackingTiles(Tile[,] board)
    {
        attackTiles.Clear();

        foreach (var tile in board)
        {
            if (tile.piece != null)
            {
                if ((tile.piece.color == PieceColor.White && GameManager.Instance.state == State.White) || ((tile.piece.color == PieceColor.Black && GameManager.Instance.state == State.Black)))
                {
                    switch (tile.piece.type)
                    {
                        case PieceType.Rook:
                            attackTiles.AddRange(CalculateRookMoves(board, tile.piece));
                            break;
                        case PieceType.Pawn:
                            attackTiles.AddRange(CalculatePawnAttacks(board, tile.piece));
                            break;
                        case PieceType.Bishop:
                            attackTiles.AddRange(CalculateBishopMoves(board, tile.piece));
                            break;
                        case PieceType.Knight:
                            attackTiles.AddRange(CalculateKnightMoves(board, tile.piece));
                            break;
                        case PieceType.Queen:
                            attackTiles.AddRange(CalculateQueenMoves(board, tile.piece));
                            break;
                        case PieceType.King:
                            attackTiles.AddRange(CalculateKingMoves(board, tile.piece));
                            break;
                    }
                    attackTiles = attackTiles.Distinct().ToList();
                }
            }
        }
    }

}
