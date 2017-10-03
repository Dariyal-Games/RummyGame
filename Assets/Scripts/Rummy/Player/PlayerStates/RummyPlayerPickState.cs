using UnityEngine;
using System.Collections;

public sealed class RummyPlayerPickState : RummyPlayerState
{
    private static readonly RummyPlayerPickState instance = new RummyPlayerPickState();
    public static RummyPlayerPickState Instance { get { return instance; } }

    public override void Enter(RummyPlayerController controller)
    {
        //Player can pick now. Listen for pick.
        controller.playerDeck.CardAdded += PlayerDeck_CardAdded;
    }

    private void PlayerDeck_CardAdded(object sender, CardAddedEventArgs e)
    {
        //Check for valid move.
        controller.ChangeState(RummyPlayerDiscardState.Instance);
    }

    public override void Exit(RummyPlayerController controller)
    {
        //Player has finished picking.
        controller.playerDeck.CardAdded -= PlayerDeck_CardAdded;
    }

    public override void Update(RummyPlayerController controller)
    {
        //Do nothing.
    }
}
