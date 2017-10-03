using UnityEngine;
using System.Collections;

public class RummyGameInitState : RummyGameState
{
    private static readonly RummyGameInitState instance = new RummyGameInitState();
    public static RummyGameInitState Instance { get { return instance; } }

    public override void Enter(RummyGameController entity)
    {
        entity.Initialize();
    }

    public override void Exit(RummyGameController entity)
    {
    }

    public override void Update(RummyGameController entity)
    {
        
    }
}
