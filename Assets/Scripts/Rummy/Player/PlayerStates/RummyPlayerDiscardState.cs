using UnityEngine;
using System.Collections;

public class RummyPlayerDiscardState : RummyPlayerState
{
    private static readonly RummyPlayerDiscardState instance = new RummyPlayerDiscardState();
    public static RummyPlayerDiscardState Instance { get { return instance; } }

    public override void Enter(RummyPlayerController controller)
    {
        Debug.Log("Entering DiscardState");
        this.controller = controller;
        controller.playerDeck.CardRemoved += PlayerDeck_CardRemoved;
    }

    private void PlayerDeck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        //Check if valid move.
        
        controller.ChangeState(RummyPlayerIdleState.Instance);
    }

    public override void Exit(RummyPlayerController controller)
    {
        Debug.Log("Exiting DiscardState");
    }

    public override void Update(RummyPlayerController controller)
    {
        
    }
}
