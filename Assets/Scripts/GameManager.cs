using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public State state;

    //public static event Action<State> OnStateChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateState(State.CreateBoard);
    }

    public void UpdateState(State newState)
    {
        state = newState;

        switch (newState)
        {
            case State.CreateBoard:
                BoardController.Instance.CreateBoard();
                break;
            case State.SetPieces:
                BoardController.Instance.SetPiecesFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w");
                break;
            case State.End:
                break;
        }
    }

    public void ChangeTurn()
    {
        if (state == State.White)
            UpdateState(State.Black);
        else
            UpdateState(State.White);
    }

}

public enum State
{
    CreateBoard,
    SetPieces,
    White,
    Black,
    End
}