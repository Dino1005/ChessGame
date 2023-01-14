using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color lightSquare, darkSquare;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] GameObject highlight;

    public Piece piece;
   

    public void Initialize(bool isLightSquared)
    {
        spriteRenderer.color = isLightSquared ? lightSquare : darkSquare;
    }

    public void EnableHighlight(Color color)
    {
        highlight.GetComponent<SpriteRenderer>().color = color;
        highlight.SetActive(true);
    }


    public void DisableHighlight()
    {
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        if (piece != null)
        {
            if ((piece.color == PieceColor.White && GameManager.Instance.state == State.White) || (piece.color == PieceColor.Black && GameManager.Instance.state == State.Black))
            {
                BoardController.Instance.DisableAllHighlights();
                EnableHighlight(BoardController.Instance.lastMoveHighlight);

                BoardController.Instance.SetSelectedPiece(piece);
                BoardController.Instance.ShowAvailableMoves();
            }

            if ((piece.color == PieceColor.White && GameManager.Instance.state != State.White) || (piece.color == PieceColor.Black && GameManager.Instance.state != State.Black))
            {
                if (BoardController.Instance.selectedPiece != null)
                {
                    if (BoardController.Instance.availableMoves.Contains(this))
                    {
                        FindObjectOfType<AudioManager>().Play("Capture");

                        BoardController.Instance.HideAvailableMoves();
                        EnableHighlight(BoardController.Instance.lastMoveHighlight);

                        Destroy(piece.gameObject);
                        MovePiece(BoardController.Instance.selectedPiece);
                        BoardController.Instance.SetSelectedPiece(null);

                        GameManager.Instance.ChangeTurn();
                    }
                }
            }
        }

        else
        {
            if (BoardController.Instance.selectedPiece != null)
            {
                if (BoardController.Instance.availableMoves.Contains(this))
                {
                    FindObjectOfType<AudioManager>().Play("Move");

                    BoardController.Instance.HideAvailableMoves();
                    EnableHighlight(BoardController.Instance.lastMoveHighlight);

                    MovePiece(BoardController.Instance.selectedPiece);
                    BoardController.Instance.SetSelectedPiece(null);

                    GameManager.Instance.ChangeTurn();
                }
                
            }
        }
    }

    public void SetPiece(Piece piece)
    {
        this.piece = piece;
        this.piece.tile = this;
        this.piece.transform.position = this.piece.tile.transform.position;
    }

    public void MovePiece(Piece piece)
    {
        var temp = piece;
        piece.tile.piece = null;
        piece.tile = this;

        SetPiece(temp);
    }
}
