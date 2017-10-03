using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RummyGameController : MonoBehaviour
{
    public CardStack DealerDeck;
    public RummyPlayerController[] players;

    public event PlayerTurnStartEventHandler PlayerTurnStarted;
    public event PlayerTurnEndEventHandler PlayerTurnEnded;

    private FiniteStateMachine<RummyGameController> stateMachine;

    private int currentPlayerID;

    private void Awake()
    {
        stateMachine = new FiniteStateMachine<RummyGameController>();
        stateMachine.Configure(this, RummyGameInitState.Instance);
    }

    private void Start()
    {

    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(RummyGameState nextState)
    {
        stateMachine.ChangeState(nextState);
    }

    public void DealCards()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                int c = DealerDeck.Pop();
                if (c != -1)
                {
                    players[i].playerDeck.Push(c);
                }
            }
        }
    }

    public void StartPlayerTurn()
    {
        if (PlayerTurnStarted != null) PlayerTurnStarted(this, new PlayerTurnStartEventArgs(currentPlayerID));
    }

    public void EndPlayerTurn()
    {
        if (PlayerTurnEnded != null) PlayerTurnEnded(this, new PlayerTurnEndEventArgs(currentPlayerID));
        IncrementCurrentPlayerID();
    }

    public void Initialize()
    {
        //Initialize the game.
        //Setup decks.
        //Deal Cards.
        DealerDeck.Initialize();

        //foreach (var player in players)
        //{
        //    player.Initialize();
        //}

        for (int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
            players[i].Initialize();
        }

        DealCards();
        currentPlayerID = 0;

        ChangeState(RummyGamePlayerTurnState.Instance);
    }

    private void IncrementCurrentPlayerID()
    {
        currentPlayerID++;
        if (currentPlayerID >= players.Length) currentPlayerID = 0;
    }
}
