using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class RummyPlayerState : FSMState<RummyPlayerController>
{
    protected int playerID;
    protected RummyPlayerController controller;
}