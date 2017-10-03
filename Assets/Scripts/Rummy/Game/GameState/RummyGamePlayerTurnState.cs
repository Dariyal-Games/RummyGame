using UnityEngine;
using System.Collections;

public class RummyGamePlayerTurnState : RummyGameState
{
    private static readonly RummyGamePlayerTurnState instance = new RummyGamePlayerTurnState();
    public static RummyGamePlayerTurnState Instance { get { return instance; } }

    public override void Enter(RummyGameController entity)
    {
        entity.StartPlayerTurn();
    }

    public override void Exit(RummyGameController entity)
    {
        entity.EndPlayerTurn();
    }

    public override void Update(RummyGameController entity)
    {
        
    }
}
