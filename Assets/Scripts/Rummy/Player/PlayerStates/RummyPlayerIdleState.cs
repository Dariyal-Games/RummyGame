using UnityEngine;
using System.Collections;

public sealed class RummyPlayerIdleState : RummyPlayerState
{
    private static readonly RummyPlayerIdleState instance = new RummyPlayerIdleState();
    public static RummyPlayerIdleState Instance { get { return instance; } }
    
    public override void Update(RummyPlayerController entity)
    {
        //Do nothing as of now.
    }

    public override void Enter(RummyPlayerController entity)
    {
        Debug.Log("Entering IdleState");
        playerID = entity.playerID;
        entity.GameController.PlayerTurnStarted += GameController_PlayerTurnStarted;
        controller = entity;
    }

    public override void Exit(RummyPlayerController entity)
    {
        entity.GameController.PlayerTurnStarted -= GameController_PlayerTurnStarted;
        controller = null;
    }

    private void GameController_PlayerTurnStarted(object sender, PlayerTurnStartEventArgs e)
    {
        if (e.PlayerID == playerID)
        {
            //ChangeState
            controller.ChangeState(RummyPlayerPickState.Instance);
        }
    }
}
