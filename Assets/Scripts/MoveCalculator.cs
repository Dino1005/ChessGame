using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveCalculator
{
    public static List<Tile> availableMoves = new List<Tile>();
    public static void CalculateKingMoves(Tile[,] board, Piece selectedPiece)
    {
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
    }

    public static void CalculateQueenMoves(Tile[,] board, Piece selectedPiece)
    {
        CalculateBishopMoves(board, selectedPiece);
        CalculateRookMoves(board, selectedPiece);
    }

    public static void CalculateKnightMoves(Tile[,] board, Piece selectedPiece)
    {
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
    }

    public static void CalculateBishopMoves(Tile[,] board, Piece selectedPiece)
    {
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
    }

    public static void CalculatePawnMoves(Tile[,] board, Piece selectedPiece)
    {
        if (selectedPiece.color == PieceColor.White)
        {
            if (selectedPiece.yValue == 1)
                if ((board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null) && (board[selectedPiece.xValue, selectedPiece.yValue + 2].piece == null))
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 2]);

            if (selectedPiece.yValue + 1 < 8)
                if (board[selectedPiece.xValue, selectedPiece.yValue + 1].piece == null)
                    availableMoves.Add(board[selectedPiece.xValue, selectedPiece.yValue + 1]);

            if (selectedPiece.yValue + 1 < 8 && selectedPiece.xValue - 1 >= 0)
                if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece != null)
                    if (board[selectedPiece.xValue - 1, selectedPiece.yValue + 1].piece.color == PieceColor.Black)
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

    public static void CalculateRookMoves(Tile[,] board, Piece selectedPiece)
    {
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
    }
}
